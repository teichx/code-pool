using Microsoft.EntityFrameworkCore;
using CodePool.Sharp.Data.EntityFramework;
using System.Diagnostics.CodeAnalysis;
using CodePool.Location.Models;

namespace CodePool.Location.Context;

[RequiresUnreferencedCode("Entity framework is not compatible with trimming")]
public sealed class LocationContext(DbContextOptions<LocationContext> options) : DbContext(options)
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => base.OnConfiguring(optionsBuilder
            .UseNpgsql()
            .UseSnakeCaseNamingConvention());

    protected override void OnModelCreating(ModelBuilder modelBuilder)
        => modelBuilder
            .AddAttributeExtensions()
            .ApplyConfigurationsFromAssembly(typeof(LocationContext).Assembly);

    public DbSet<Country> Country { get; set; }
    public DbSet<State> State { get; set; }
    public DbSet<City> City { get; set; }
}
