namespace DessertsMakery.Telegram.Application.Menu;

internal sealed class MenuFactory
{
    public MenuRoot Create()
    {
        var root = new MenuRoot();
        AppendComponents(root);
        AppendPurchases(root);
        return root;
    }

    private static void AppendComponents(MenuRoot root)
    {
        var components = root.AppendSection(MenuSectionNames.Essential.Components);

        var additions = components.AppendChild(MenuSectionNames.Essential.Additions);
        additions.AppendChild(MenuSectionNames.Common.Add);
        additions.AppendChild(MenuSectionNames.Common.Remove);

        var ingredients = components.AppendChild(MenuSectionNames.Essential.Ingredients);
        ingredients.AppendChild(MenuSectionNames.Common.Add);
        ingredients.AppendChild(MenuSectionNames.Common.Remove);

        var packagingComponents = components.AppendChild(MenuSectionNames.Essential.PackagingComponents);
        packagingComponents.AppendChild(MenuSectionNames.Common.Add);
        packagingComponents.AppendChild(MenuSectionNames.Common.Remove);
    }

    private static void AppendPurchases(MenuRoot root)
    {
        var purchases = root.AppendSection(MenuSectionNames.Purchase.Purchases);
    }
}
