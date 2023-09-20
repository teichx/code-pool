using CodePool.Sharp.EnvironmentData;
using Microsoft.Extensions.Configuration;
using Microsoft.FeatureManagement;
using StackExchange.Redis;

namespace CodePool.Sharp.FeatureManagement.Redis;

internal sealed class RedisFeatureDefinitionProvider(IConfiguration configuration) : IFeatureDefinitionProvider
{
    readonly ConnectionMultiplexer _redis = ConnectionMultiplexer.Connect(
        configuration.GetConnectionString(EnvironmentConst.RedisFeatureFlags)!
    );

    public async IAsyncEnumerable<FeatureDefinition> GetAllFeatureDefinitionsAsync()
    {
        List<string> list = ["CustomerIdTest", "PercentageTest", "TimeWindowMuitoLegal"];
        foreach (var name in list)
        {
            yield return await GetFeatureDefinitionAsync(name);
        }
    }

    public async Task<FeatureDefinition> GetFeatureDefinitionAsync(string featureName)
    {
        var redisValue = await _redis.GetDatabase().StringGetAsync(featureName);

        return redisValue.HasValue ? (RedisFeatureDefinition)redisValue : RedisFeatureDefinition.Empty;
    }
}
