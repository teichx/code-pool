using CodePool.Sharp.FeatureManagement.FeatureFilters.Interfaces;
using CodePool.Sharp.ValueObject;

namespace CodePool.Sharp.FeatureManagement.FeatureFilters;

public readonly struct CustomerIdContext : ICustomerIdContext
{
    public CustomerId CustomerId { get; init; }
}
