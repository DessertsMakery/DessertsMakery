using CSharpFunctionalExtensions;

namespace DessertsMakery.Telegram.Application.Menu;

public sealed class Breadcrumbs
{
    private const int StartingLevel = 1;
    private const char Separator = ':';

    private readonly List<IMenuSection> _sections = new();
    public IReadOnlyCollection<IMenuSection> Sections => _sections;

    public IMenuSection Current => _sections.Last();

    private Breadcrumbs(IMenuSection root) => _sections.Add(root);

    public Breadcrumbs GoTo(string name)
    {
        var section = Current.TryFindChild(name).GetValueOrThrow($"Cannot find a section with the name `{name}`");
        _sections.Add(section);
        return this;
    }

    public Breadcrumbs Back()
    {
        _sections.RemoveAt(_sections.Count - 1);
        return this;
    }

    public override string ToString() => string.Join(Separator, Sections.Select(x => x.Name));

    public static Breadcrumbs Empty(IMenuRoot root) => new(root);

    public static Maybe<Breadcrumbs> TryFrom(IMenuRoot root, string? source)
    {
        if (string.IsNullOrWhiteSpace(source))
        {
            return Maybe.None;
        }

        if (root.Name == source)
        {
            return Empty(root);
        }

        var breadcrumbs = TrySplitToBreadcrumbs(root, source);

        var level = StartingLevel;
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

    private static string[] TrySplitToBreadcrumbs(IMenuSection root, string source)
    {
        var breadcrumbs = source.Split(Separator);
        if (breadcrumbs.First() != root.Name)
        {
            throw new InvalidOperationException($"First element should always be `{root.Name}`");
        }

        return breadcrumbs;
    }

    private static Breadcrumbs From(IMenuRoot root, IMenuSection section)
    {
        var breadcrumbs = Empty(root);
        var current = section;
        while (current.Parent is not null)
        {
            breadcrumbs._sections.Insert(StartingLevel, current);
            current = current.Parent;
        }

        return breadcrumbs;
    }
}
