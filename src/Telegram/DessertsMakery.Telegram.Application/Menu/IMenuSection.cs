namespace DessertsMakery.Telegram.Application.Menu;

public interface IMenuSection
{
    string? Name { get; }
    IMenuSection? Parent { get; }
    IEnumerable<IMenuSection> Children { get; }
}
