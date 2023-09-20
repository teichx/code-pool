using CodePool.Sharp.FeatureManagement.FeatureFilters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.FeatureManagement;
using Microsoft.FeatureManagement.FeatureFilters;

namespace CodePool.Sharp.FeatureManagement.Redis;

public static class FeatureManagementExtension
{
    public static IServiceCollection ExtendRedisFeatureManagement(this IServiceCollection services)
    {
        services.AddSingleton<IFeatureDefinitionProvider, RedisFeatureDefinitionProvider>();
        // services.AddSingleton<IFeatureManager, FeatureManager>();
        // services.AddSingleton<ISessionManager, EmptySessionManager>();
        // services.AddScoped<IFeatureManagerSnapshot, FeatureManagerSnapshot>();
        // var featureManagementBuilder = new FeatureManagementBuilder(services);

        var featureManagementBuilder = services.AddFeatureManagement();
        services.AddSingleton<IFeatureManager, FeatureManager>();

        featureManagementBuilder
            .AddFeatureFilter<PercentageFilter>()
            .AddFeatureFilter<TimeWindowFilter>()
            .AddFeatureFilter<CustomerIdFilter>();

        return services;
    }
}
