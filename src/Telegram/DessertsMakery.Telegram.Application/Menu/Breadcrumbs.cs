using CSharpFunctionalExtensions;

namespace DessertsMakery.Telegram.Application.Menu;

public sealed class Breadcrumbs
{
    private const char Separator = ':';

    private readonly Stack<IMenuSection> _sections = new();
    public IReadOnlyCollection<IMenuSection> Sections => _sections;

    public IMenuSection Current => _sections.Peek();

    private Breadcrumbs(IMenuSection root) => _sections.Push(root);

    public Breadcrumbs GoTo(string name)
    {
        var section = Current.TryFindChild(name).GetValueOrThrow($"Cannot find a section with the name `{name}`");
        _sections.Push(section);
        return this;
    }

    public Breadcrumbs Back()
    {
        _sections.Pop();
        return this;
    }

    public override string ToString() => string.Join(Separator, Sections.Select(x => x.Name));

    public static Breadcrumbs Empty(IMenuRoot root) => new(root);

    public static Maybe<Breadcrumbs> TryFrom(IMenuRoot root, string? source)
    {
        if (string.IsNullOrWhiteSpace(source))
        {
            return Empty(root);
        }

        var breadcrumbs = source.Split(Separator);

        var level = 0;
        IMenuParent current = root;
        while (level < breadcrumbs.Length)
        {
            var name = breadcrumbs[level];
            var child = current.TryFindChild(name);
            if (child.HasNoValue)
            {
                return Maybe.None;
            }

            current = child.Value;
            level++;
        }

        return From(root, (IMenuSection)current);
    }

    private static Breadcrumbs From(IMenuRoot root, IMenuSection section)
    {
        var breadcrumbs = Empty(root);
        var current = section;
        while (current.Parent is not null)
        {
            breadcrumbs._sections.Push(current);
            current = current.Parent;
        }

        return breadcrumbs;
    }
}
