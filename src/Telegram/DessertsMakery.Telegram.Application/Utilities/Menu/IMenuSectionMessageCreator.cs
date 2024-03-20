using DessertsMakery.Telegram.Application.Menu;

namespace DessertsMakery.Telegram.Application.Utilities.Menu;

internal interface IMenuSectionMessageCreator
{
    bool CanBeUsed(Breadcrumbs breadcrumbs);
    TelegramMessage Create();
}
