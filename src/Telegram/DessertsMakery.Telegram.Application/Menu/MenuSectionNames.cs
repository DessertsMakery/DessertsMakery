namespace DessertsMakery.Telegram.Application.Menu;

public static class MenuSectionNames
{
    public const string Root = nameof(Root);

    public static class Essential
    {
        public const string Components = nameof(Components);
        public const string Additions = nameof(Additions);
        public const string Ingredients = nameof(Ingredients);
        public const string PackagingComponents = nameof(PackagingComponents);
    }

    public static class Purchase
    {
        public const string Purchases = nameof(Purchases);
    }

    public static class Common
    {
        public const string Add = nameof(Add);
        public const string Remove = nameof(Remove);
        public const string Back = nameof(Back);
    }
}
