using MediatR;

namespace TaxCalculator.Application.TaxForecasts.Commands.CreateTaxForecast;

public record CreateTaxForecastCommand : IRequest<long>
{
    public string Title { get; init; } = string.Empty;
}
