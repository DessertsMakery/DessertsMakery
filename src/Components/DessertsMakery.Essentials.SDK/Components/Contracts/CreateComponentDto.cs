namespace DessertsMakery.Essentials.SDK.Components.Contracts;

public sealed record CreateComponentDto(
    string Name,
    string Measuring,
    string ComponentType,
    Guid? ParentId = null,
    decimal? Proportion = null
);
