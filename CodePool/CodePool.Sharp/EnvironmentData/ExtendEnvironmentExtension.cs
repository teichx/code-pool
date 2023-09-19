using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace CodePool.Sharp.EnvironmentData;

public static class ExtendEnvironmentExtension
{
    public static IServiceCollection ExtendEnvironment(this IServiceCollection services)
    {
        var projectName = Assembly.GetEntryAssembly()?.GetName().Name ?? string.Empty;
        Environment.SetEnvironmentVariable(EnvironmentConst.ProjectName, projectName);
        return services;
    }
}
