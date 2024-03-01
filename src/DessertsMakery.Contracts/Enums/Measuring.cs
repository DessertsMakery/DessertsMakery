using Ardalis.SmartEnum;

namespace DessertsMakery.Contracts.Enums;

public sealed class Measuring : SmartEnum<Measuring>
{
    public static readonly Measuring Quantity = new(nameof(Quantity), 1);
    public static readonly Measuring Gram = new(nameof(Gram), 2);

    private Measuring(string name, int value)
        : base(name, value) { }
}
