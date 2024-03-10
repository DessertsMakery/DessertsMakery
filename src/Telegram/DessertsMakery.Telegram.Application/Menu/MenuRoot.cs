using CSharpFunctionalExtensions;

namespace DessertsMakery.Telegram.Application.Menu;

internal sealed class MenuRoot : IMenuRoot
{
    private readonly List<MenuSection> _sections = new();

    public string Name => MenuSectionNames.Root;
    public IMenuSection? Parent => null;
    public IEnumerable<IMenuSection> Children => _sections.AsReadOnly();

    public Maybe<IMenuSection> TryFindChild(string name) =>
        Children.TryFirst(x => x.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

    internal MenuSection AppendSection(string name)
    {
        var section = new MenuSection(name, this);
        _sections.Add(section);
        return section;
    }
}
