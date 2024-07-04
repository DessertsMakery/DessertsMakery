using System.Collections.Concurrent;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using Castle.DynamicProxy;
using MongoDB.Driver;

namespace DessertsMakery.Common.Persistence.Mongo;

internal sealed class MongoCollectionProvider(IMongoDatabase database, ICollectionNamingStrategy namingStrategy)
    : IMongoCollectionProvider
{
    private static readonly Type InternalCollectionInterface = typeof(IMongoEntityCollection<>);
    private static readonly ProxyGenerator ProxyGenerator = new();
    private static readonly ConcurrentDictionary<Type, Func<IMongoEntityCollection>> LazyCollections = new();

    public IMongoEntityCollection Create(Type entityType)
    {
        var factory = LazyCollections.GetOrAdd(
            entityType,
            key =>
            {
                var collectionName = namingStrategy.GetName(entityType);
                database.CreateCollection(collectionName);
                return () => GetBy(key, collectionName);
            }
        );
        return factory();
    }

    private IMongoEntityCollection GetBy(Type entityType, string collectionName)
    {
        var openGenericMethod = typeof(IMongoDatabase).GetMethod(nameof(IMongoDatabase.GetCollection))!;
        var getCollectionMethod = openGenericMethod.MakeGenericMethod(entityType);

        var arguments = new object?[] { collectionName, null };
        var collection = getCollectionMethod.Invoke(database, arguments)!;

        var interceptor = new MongoEntityCollectionInterceptor(entityType, collection);
        var internalInterface = InternalCollectionInterface.MakeGenericType(entityType);
        return (IMongoEntityCollection)ProxyGenerator.CreateInterfaceProxyWithoutTarget(internalInterface, interceptor);
    }

    private class MongoEntityCollectionInterceptor(Type entityType, object mongoCollection) : IInterceptor
    {
        private static readonly Type OpenGenericInterface = typeof(IMongoCollection<>);
        private readonly Type _mongoCollectionInterface = OpenGenericInterface.MakeGenericType(entityType);

        public void Intercept(IInvocation invocation)
        {
            var method = GetMethod(invocation);
            invocation.ReturnValue = method.Invoke(mongoCollection, invocation.Arguments);
        }

        private MethodInfo GetMethod(IInvocation invocation)
        {
            var methodName = invocation.Method.Name;
            var parameters = invocation.Method.GetParameters().ToArray();

            var method = _mongoCollectionInterface
                .GetMethods()
                .Where(method => methodName.Equals(method.Name, StringComparison.Ordinal))
                .Where(method => SameGenericArguments(invocation.Method, method))
                .FirstOrDefault(method => SameParameters(method, parameters));

            if (method is null)
            {
                ThrowNotSupportedMethod(invocation);
            }

            if (!method.IsGenericMethodDefinition)
            {
                return method;
            }

            return method.MakeGenericMethod(invocation.GenericArguments);
        }

        private static bool SameGenericArguments(MethodInfo actualMethod, MethodInfo expectedMethod)
        {
            if (actualMethod.IsGenericMethod != expectedMethod.IsGenericMethod)
            {
                return false;
            }

            if (!actualMethod.IsGenericMethod)
            {
                return true;
            }

            var actualArguments = actualMethod.GetGenericMethodDefinition().GetGenericArguments();
            var expectedArguments = expectedMethod.GetGenericArguments();
            if (actualArguments.Length != expectedArguments.Length)
            {
                return false;
            }

            var argumentPairs = actualArguments.Zip(expectedArguments);
            foreach (var (actual, expected) in argumentPairs)
            {
                if (actual != expected)
                {
                    return false;
                }
            }
            return true;
        }

        private static bool SameParameters(MethodInfo method, ParameterInfo[] actualParameters)
        {
            var expectedParameters = method.GetParameters();
            if (actualParameters.Length != expectedParameters.Length)
            {
                return false;
            }

            foreach (var (actual, expected) in actualParameters.Zip(expectedParameters))
            {
                if (NotSameParameters(actual, expected))
                {
                    return false;
                }
            }

            return true;
        }

        private static bool NotSameParameters(ParameterInfo actual, ParameterInfo expected) =>
            !SameParameters(actual, expected);

        private static bool SameParameters(ParameterInfo actual, ParameterInfo expected)
        {
            if (!SameParameterTypes(actual.ParameterType, expected.ParameterType))
            {
                return false;
            }

            if (actual.Name != expected.Name)
            {
                return false;
            }

            if (actual.Attributes != expected.Attributes)
            {
                return false;
            }

            return true;
        }

        private static bool SameParameterTypes(Type actual, Type expected)
        {
            if (!expected.ContainsGenericParameters)
            {
                return actual == expected;
            }

            if (expected.IsGenericParameter)
            {
                var constraints = expected.GetGenericParameterConstraints();
                return constraints.All(x => x.IsAssignableFrom(actual));
            }

            var actualArguments = actual.GetGenericArguments();
            var expectedArguments = expected.GetGenericArguments();
            foreach (var (actualArgument, expectedArgument) in actualArguments.Zip(expectedArguments))
            {
                if (!SameParameterTypes(actualArgument, expectedArgument))
                {
                    return false;
                }
            }
            return true;
        }

        [DoesNotReturn]
        private void ThrowNotSupportedMethod(IInvocation invocation) =>
            throw new NotSupportedException(
                $"Method `{invocation.Method.Name}` is not implemented in {_mongoCollectionInterface}."
            );
    }
}
