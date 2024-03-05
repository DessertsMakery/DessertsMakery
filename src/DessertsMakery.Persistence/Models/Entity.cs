namespace DessertsMakery.Persistence.Models;

public abstract class Entity
{
    public long InternalId { get; internal init; }
    public Guid ExternalId { get; internal set; }
    public DateTime CreatedAt { get; internal set; }
    public DateTime ModifiedAt { get; internal set; }
    public bool IsDeleted { get; internal set; }
}
