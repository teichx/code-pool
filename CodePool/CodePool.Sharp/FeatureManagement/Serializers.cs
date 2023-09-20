using System.Text.Json.Serialization;
using CodePool.Sharp.FeatureManagement.Dto;

namespace CodePool.Sharp.FeatureManagement.Redis;



[JsonSourceGenerationOptions]
[JsonSerializable(typeof(FeatureFilterConfigurationDto))]
sealed partial class FeatureFilterConfigurationDtoContext : JsonSerializerContext
{
}

[JsonSourceGenerationOptions]
[JsonSerializable(typeof(FeatureFiltersParametersDto))]
sealed partial class FeatureFiltersParametersDtoContext : JsonSerializerContext
{
}
