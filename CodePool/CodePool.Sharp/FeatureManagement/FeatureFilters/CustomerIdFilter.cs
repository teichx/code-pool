using CodePool.Sharp.FeatureManagement.FeatureFilters.Interfaces;
using CodePool.Sharp.ValueObject;
using Microsoft.Extensions.Configuration;
using Microsoft.FeatureManagement;

namespace CodePool.Sharp.FeatureManagement.FeatureFilters;

[FilterAlias("CustomerId")]
internal sealed class CustomerIdFilter : IContextualFeatureFilter<ICustomerIdContext>
{
    public Task<bool> EvaluateAsync(
        FeatureFilterEvaluationContext featureEvaluationContext,
        ICustomerIdContext customerIdContext
    )
    {
        if (customerIdContext is null) return Task.FromResult(false);
        if (CustomerId.Empty.Equals(customerIdContext.CustomerId)) return Task.FromResult(false);

        var allowedCustomerIds = new List<int>();
        featureEvaluationContext.Parameters.Bind("AllowedCustomerIds", allowedCustomerIds);

        return Task.FromResult(allowedCustomerIds.Contains(customerIdContext.CustomerId));
    }
}
