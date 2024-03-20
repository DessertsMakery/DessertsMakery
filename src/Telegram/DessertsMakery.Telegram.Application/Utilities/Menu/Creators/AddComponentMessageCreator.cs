using DessertsMakery.Telegram.Application.Menu;
using DessertsMakery.Telegram.Application.Utilities.Localization;

namespace DessertsMakery.Telegram.Application.Utilities.Menu.Creators;

internal sealed class AddComponentMessageCreator : IMenuSectionMessageCreator
{
    private const string AddComponent = nameof(AddComponent);
    private static readonly string[] AllowedComponents =
    {
        MenuSectionNames.Essential.Additions,
        MenuSectionNames.Essential.Ingredients,
        MenuSectionNames.Essential.PackagingComponents
    };

    private readonly ITelegramMessageLocalizer _telegramMessageLocalizer;

    public AddComponentMessageCreator(ITelegramMessageLocalizer telegramMessageLocalizer)
    {
        _telegramMessageLocalizer = telegramMessageLocalizer;
    }

    public bool CanBeUsed(Breadcrumbs breadcrumbs)
    {
        if (breadcrumbs.Sections.Count != 4)
        {
            return false;
        }

        if (breadcrumbs.Sections[0].Name != MenuSectionNames.Root)
        {
            return false;
        }

        if (breadcrumbs.Sections[1].Name != MenuSectionNames.Essential.Components)
        {
            return false;
        }

        if (!AllowedComponents.Contains(breadcrumbs.Sections[2].Name))
        {
            return false;
        }

        if (breadcrumbs.Sections[3].Name != MenuSectionNames.Common.Add)
        {
            return false;
        }

        return true;
    }

    public TelegramMessage Create()
    {
        var text = _telegramMessageLocalizer.Localize(LocalizationPart.Messages, AddComponent);
        return new TelegramMessage(text);
    }
}
