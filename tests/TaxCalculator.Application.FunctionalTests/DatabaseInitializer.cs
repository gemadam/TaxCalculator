using TaxCalculator.Domain.Entities;
using TaxCalculator.Infrastructure.Data;

namespace TaxCalculator.Application.FunctionalTests;

public static class DatabaseInitializer
{
    public static IReadOnlyList<TaxForecast> TaxForecasts => new List<TaxForecast>()
    {
        new TaxForecast()
        {
            Title = "Test forecast",
            IncomeSources = new List<IncomeSource>()
            {
                new IncomeSource()
                {
                    Name = "Income #1",
                    Amount = 10000
                }
            },
        }
    };

    public static async Task SeedDatabaseAsync(ApplicationDbContext dbContext,
        CancellationToken cancellationToken = default)
    {
        await dbContext.TaxForecasts.AddRangeAsync(TaxForecasts, cancellationToken);
    }
}