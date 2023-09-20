using System.Text.Json;
using CodePool.Sharp.FeatureManagement.Dto;
using Microsoft.FeatureManagement;
using StackExchange.Redis;

namespace CodePool.Sharp.FeatureManagement.Redis;

public class RedisFeatureDefinition : FeatureDefinition
{
    public new IEnumerable<FeatureFilterConfigurationDto> EnabledFor { get; set; } =
        Enumerable.Empty<FeatureFilterConfigurationDto>();

    static readonly Lazy<RedisFeatureDefinition> _empty = new(() => new()
    {
        Name = string.Empty,
        EnabledFor = Enumerable.Empty<FeatureFilterConfigurationDto>(),
        RequirementType = RequirementType.Any,
    });
    public static readonly RedisFeatureDefinition Empty = _empty.Value;

    public static implicit operator RedisFeatureDefinition(RedisValue redisValue)
    {
        var dto = JsonSerializer.Deserialize(
            redisValue.ToString(),
            RedisFeatureDefinitionContext.Default.RedisFeatureDefinition
        );
        if (string.IsNullOrEmpty(dto?.Name)) return Empty;

        return dto;
    }

    public static implicit operator string(RedisFeatureDefinition featureFlagRedisValue)
        => JsonSerializer.Serialize(featureFlagRedisValue);
}
