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
}
