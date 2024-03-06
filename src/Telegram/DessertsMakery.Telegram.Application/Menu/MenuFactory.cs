namespace DessertsMakery.Telegram.Application.Menu;

internal sealed class MenuFactory
{
    public MenuRoot Create()
    {
        var root = new MenuRoot();
        AppendComponents(root);
        return root;
    }

    private static void AppendComponents(MenuRoot root)
    {
        var components = root.AppendSection(MenuSectionNames.Components);

        var additions = components.AppendChild(MenuSectionNames.Additions);
        additions.AppendChild(MenuSectionNames.Common.Add);
        additions.AppendChild(MenuSectionNames.Common.Remove);

        var ingredients = components.AppendChild(MenuSectionNames.Ingredients);
        ingredients.AppendChild(MenuSectionNames.Common.Add);
        ingredients.AppendChild(MenuSectionNames.Common.Remove);

        var packagingComponents = components.AppendChild(MenuSectionNames.PackagingComponents);
        packagingComponents.AppendChild(MenuSectionNames.Common.Add);
        packagingComponents.AppendChild(MenuSectionNames.Common.Remove);
    }
}
