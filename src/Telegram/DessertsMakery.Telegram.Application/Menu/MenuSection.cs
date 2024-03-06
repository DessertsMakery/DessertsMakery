namespace DessertsMakery.Telegram.Application.Menu;

internal sealed class MenuSection : IMenuSection
{
    private readonly List<MenuSection> _children = new();

    public string? Name { get; }
    public IMenuSection? Parent { get; }

    public IEnumerable<IMenuSection> Children => _children.AsReadOnly();

    internal MenuSection(string name)
    {
        Name = name;
    }

    internal MenuSection(string name, IMenuSection parent)
    {
        Name = name;
        Parent = parent;
    }

    internal MenuSection AppendChild(string name)
    {
        var section = new MenuSection(name);
        _children.Add(section);
        return section;
    }
}
