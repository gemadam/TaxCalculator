using TaxCalculator.Application.Common.Models;
using TaxCalculator.Domain.Entities;

namespace TaxCalculator.Application.Common.Repositories;

public interface ITaxForecastsRepository
{
    Task<PaginatedList<TaxForecast>> GetTaxForecastsAsync(PaginatedQuery pagination,
        CancellationToken cancellationToken);
    Task<long> CreateTaxForecastsAsync(TaxForecast taxForecast,
        CancellationToken cancellationToken);
}
