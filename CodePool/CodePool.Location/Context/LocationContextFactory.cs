using System.Diagnostics.CodeAnalysis;
using CodePool.Sharp.Data.EntityFramework;

namespace CodePool.Location.Context;

[RequiresUnreferencedCode("Entity framework is not compatible with trimming")]
public class LocationContextFactory : BaseContextFactory<LocationContext>
{
    public override LocationContext CreateDbContext(string[] args)
        => new(Options);
}
