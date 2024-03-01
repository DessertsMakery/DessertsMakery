namespace DessertsMakery.Persistence;

public sealed class PersistenceConfiguration
{
    public string? Folder { get; set; }
    public string FileName { get; set; } = "desserts_makery.db";
}
