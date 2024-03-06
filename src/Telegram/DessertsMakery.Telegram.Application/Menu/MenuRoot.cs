namespace DessertsMakery.Telegram.Application.Menu;

internal sealed class MenuRoot : IMenuRoot
{
    private readonly List<MenuSection> _sections = new();

    public string? Name => null;
    public IMenuSection? Parent => null;
    public IEnumerable<IMenuSection> Children => _sections.AsReadOnly();

    internal MenuSection AppendSection(string name)
    {
        var section = new MenuSection(name);
        _sections.Add(section);
        return section;
    }
}
