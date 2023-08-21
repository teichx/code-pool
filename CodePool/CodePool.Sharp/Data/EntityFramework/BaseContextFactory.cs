using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace CodePool.Sharp.Data.EntityFramework;

public class BaseContextFactory<TContext> : IDesignTimeDbContextFactory<TContext> where TContext : DbContext
{
    public virtual TContext CreateDbContext(string[] args)
        => throw new NotImplementedException();

    public DbContextOptions<TContext> Options
    {
        get
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile(path: "appsettings.json", optional: false)
                .AddJsonFile(path: $"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", optional: true)
                .Build();

            var connectionString = configuration.GetConnectionString("PostgresSQL")
                ?? throw new InvalidOperationException("Connection string 'PostgresSQL' not found.");

            var optionsBuilder = new DbContextOptionsBuilder<TContext>();
            optionsBuilder.UseNpgsql(connectionString);

            return optionsBuilder.Options;
        }
    }
}
