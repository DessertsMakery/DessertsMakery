using Ardalis.SmartEnum;

namespace DessertsMakery.Contracts.Enums;

public sealed class RecipeDescriptionItemType : SmartEnum<RecipeDescriptionItemType>
{
    public static readonly RecipeDescriptionItemType Step = new(nameof(Step), 1);
    public static readonly RecipeDescriptionItemType Remark = new(nameof(Remark), 2);

    public RecipeDescriptionItemType(string name, int value)
        : base(name, value) { }
}
