namespace DessertsMakery.Persistence.Models;

public abstract class Entity
{
    public long InternalId { get; init; }
    public Guid ExternalId { get; init; }
    public DateTime CreatedAt { get; init; }
    public DateTime ModifiedAt { get; set; }
    public bool IsDeleted { get; set; }
}
