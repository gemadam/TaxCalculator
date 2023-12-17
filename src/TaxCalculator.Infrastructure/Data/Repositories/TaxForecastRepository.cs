using Microsoft.EntityFrameworkCore;
using TaxCalculator.Application.Common.Models;
using TaxCalculator.Application.Common.Repositories;
using TaxCalculator.Domain.Entities;

namespace TaxCalculator.Infrastructure.Data.Repositories;

public sealed class TaxForecastRepository : ITaxForecastsRepository
{
    private readonly ApplicationDbContext _dbContext;

    public TaxForecastRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<PaginatedList<TaxForecast>> GetTaxForecastsAsync(PaginatedQuery pagination,
        CancellationToken cancellationToken)
    {
        var totalCount = await _dbContext.TaxForecasts.CountAsync();

        return new PaginatedList<TaxForecast>
        {
            PageNumber = pagination.PageNumber,
            PageSize = pagination.PageSize,
            TotalCount = totalCount,
            TotalPages = totalCount / pagination.PageSize,
            Items = await _dbContext.TaxForecasts.Skip(pagination.PageNumber * pagination.PageSize)
                .Take(pagination.PageSize)
                .ToListAsync()
        };
    }

    public async Task<long> CreateTaxForecastsAsync(TaxForecast taxForecast, CancellationToken cancellationToken)
    {
        var entry = await _dbContext.TaxForecasts.AddAsync(taxForecast, cancellationToken);

        await _dbContext.SaveChangesAsync(cancellationToken);

        return entry.Entity.Id;
    }
}
