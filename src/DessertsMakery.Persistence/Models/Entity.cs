namespace DessertsMakery.Persistence.Models;

public abstract class Entity
{
    public long InternalId { get; set; }
    public Guid ExternalId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime ModifiedAt { get; set; }
    public bool IsDeleted { get; set; }
}
