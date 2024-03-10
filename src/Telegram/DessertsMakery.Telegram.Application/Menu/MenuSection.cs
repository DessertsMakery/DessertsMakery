using CSharpFunctionalExtensions;

namespace DessertsMakery.Telegram.Application.Menu;

internal sealed class MenuSection : IMenuSection
{
    private readonly List<MenuSection> _children = new();

    public string Name { get; }
    public IMenuSection? Parent { get; }

    public IEnumerable<IMenuSection> Children => _children.AsReadOnly();

    public Maybe<IMenuSection> TryFindChild(string name) =>
        Children.TryFirst(x => x.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

    internal MenuSection(string name, IMenuSection parent)
    {
        Name = name;
        Parent = parent;
    }

    internal MenuSection AppendChild(string name)
    {
        var section = new MenuSection(name, this);
        _children.Add(section);
        return section;
    }
}
