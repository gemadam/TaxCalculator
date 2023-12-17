using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TaxCalculator.Domain.Entities;

namespace TaxCalculator.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {

    }

    public DbSet<TaxForecast> TaxForecasts => Set<TaxForecast>();
    public DbSet<IncomeSource> IncomeSources => Set<IncomeSource>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(builder);
    }
}
