namespace DessertsMakery.Persistence.Models.Consumables;

public sealed class ConsumablePackagingImage : Entity
{
    public byte[] Image { get; set; } = null!;

    public long ConsumablePackagingId { get; set; }
    public ConsumablePackaging ConsumablePackaging { get; set; } = null!;
}
