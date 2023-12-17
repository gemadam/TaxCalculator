using TaxCalculator.Application.Common.Models;
using TaxCalculator.Domain.Entities;

namespace TaxCalculator.Application.TaxForecasts.Queries.GetTaxForecasts;

public sealed record GetTaxForecastsResult
{
    public PaginatedList<TaxForecast> TaxForecasts { get; init; }
}
