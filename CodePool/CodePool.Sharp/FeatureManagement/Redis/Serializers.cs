using System.Text.Json.Serialization;

namespace CodePool.Sharp.FeatureManagement.Redis;

[JsonSourceGenerationOptions]
[JsonSerializable(typeof(RedisFeatureDefinition))]
sealed partial class RedisFeatureDefinitionContext : JsonSerializerContext
{
}
