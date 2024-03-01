namespace DessertsMakery.Common.Wrappers;

internal sealed class DateTimeWrapper : IDateTimeProvider, IWrapper
{
    public DateTime GetUtcNow() => DateTime.UtcNow;
}
