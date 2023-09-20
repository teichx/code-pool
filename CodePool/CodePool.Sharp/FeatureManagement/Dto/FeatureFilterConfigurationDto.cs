using Microsoft.FeatureManagement;

namespace CodePool.Sharp.FeatureManagement.Dto;

public class FeatureFilterConfigurationDto : FeatureFilterConfiguration
{
    public new FeatureFiltersParametersDto Parameters { get; set; } = FeatureFiltersParametersDto.Empty;
}
