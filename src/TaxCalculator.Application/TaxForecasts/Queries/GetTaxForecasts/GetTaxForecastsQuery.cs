using MediatR;
using TaxCalculator.Application.Common.Models;

namespace TaxCalculator.Application.TaxForecasts.Queries.GetTaxForecasts;

public record GetTaxForecastsQuery : PaginatedQuery, IRequest<GetTaxForecastsResult>;
