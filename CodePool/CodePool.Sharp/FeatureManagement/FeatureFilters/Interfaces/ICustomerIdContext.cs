using CodePool.Sharp.ValueObject;

namespace CodePool.Sharp.FeatureManagement.FeatureFilters.Interfaces;

public interface ICustomerIdContext
{
    CustomerId CustomerId { get; }
}
