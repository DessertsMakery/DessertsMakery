using CSharpFunctionalExtensions;

namespace DessertsMakery.Telegram.Application.Menu;

public interface IMenuParent
{
    IEnumerable<IMenuSection> Children { get; }
    Maybe<IMenuSection> TryFindChild(string name);
}
