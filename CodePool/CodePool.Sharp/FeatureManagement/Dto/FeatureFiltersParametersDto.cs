using CodePool.Sharp.ValueObject;

namespace CodePool.Sharp.FeatureManagement.Dto;

public class FeatureFiltersParametersDto
{
    public IEnumerable<CustomerId> AllowedCustomerIds { get; internal set; } = Enumerable.Empty<CustomerId>();
    public int Value { get; internal set; } = -1;

    public static readonly FeatureFiltersParametersDto Empty = new();
}
