using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Reflection;

namespace CodePool.Sharp.Data.EntityFramework;

public static class EFCoreAttributeExtension
{
    private static ModelBuilder AddByAttribute<TAttribute>(
        this ModelBuilder modelBuilder,
        Action<(IMutableProperty EntityProperty, TAttribute CustomAttribute)> action
    ) where TAttribute : Attribute
    {
        modelBuilder.Model
           .GetEntityTypes()
           .SelectMany(x => x
               .GetProperties()
               .Select(y => (
                    EntityProperty: y,
                    CustomAttribute: y.PropertyInfo?
                        .GetCustomAttribute<TAttribute>(true)
                ))
               .Where(y => y.CustomAttribute is not null)
               .Select(y => (y.EntityProperty,
                    CustomAttribute: y.CustomAttribute!
                ))
           )
           .ToList()
           .ForEach(action);

        return modelBuilder;
    }

    public static ModelBuilder AddDefaultSqlValues(this ModelBuilder modelBuilder)
        => modelBuilder
            .AddByAttribute<DefaultSqlValueAttribute>(x => x
                .EntityProperty
                .SetDefaultValueSql(x.CustomAttribute.ToString()));

    public static ModelBuilder AddAttributeExtensions(this ModelBuilder modelBuilder)
        => modelBuilder
            .AddDefaultSqlValues();
}
