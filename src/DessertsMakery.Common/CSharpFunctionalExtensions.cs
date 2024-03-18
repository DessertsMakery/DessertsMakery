using CSharpFunctionalExtensions;

namespace DessertsMakery.Common;

public static class CSharpFunctionalExtensions
{
    public static Maybe<T> Tap<T>(this Maybe<T> maybe, Action<T> action)
    {
        if (maybe.HasValue)
        {
            action(maybe.Value);
        }

        return maybe;
    }

    public static async Task<Maybe<T>> Tap<T>(this Maybe<T> maybe, Func<T, Task> action)
    {
        if (maybe.HasValue)
        {
            await action(maybe.Value);
        }

        return maybe;
    }

    public static async Task<Maybe<T>> Tap<T>(this Task<Maybe<T>> task, Action<T> action) => (await task).Tap(action);
}
