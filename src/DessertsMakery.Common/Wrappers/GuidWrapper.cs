namespace DessertsMakery.Common.Wrappers;

internal sealed class GuidWrapper : IGuidProvider, IWrapper
{
    public Guid GetGuid() => Guid.NewGuid();
}
