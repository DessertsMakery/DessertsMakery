namespace DessertsMakery.Telegram.Application.Menu;

public interface IMenuSection : IMenuParent
{
    string Name { get; }
    IMenuSection? Parent { get; }
}
