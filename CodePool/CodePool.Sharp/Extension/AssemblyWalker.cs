using System.Reflection;

namespace CodePool.Sharp.Extension;

internal static class AssemblyWalker
{
    public static IList<Assembly> Assemblies => AppDomain.CurrentDomain
        .GetAssemblies()
        .ToList();

    public static IEnumerable<Type> InterfacesWithAttribute<T>() where T : Attribute
        => Assemblies
            .SelectMany(x => x
                .GetTypes()
                .Where(x => x.IsInterface)
                .Where(x => x.GetCustomAttributes<T>(true).Any())
            )
            .Distinct();
}
