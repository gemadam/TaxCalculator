using MediatR;
using TaxCalculator.Application.Common.Repositories;

namespace TaxCalculator.Application.TaxForecasts.Queries.GetTaxForecasts;

public sealed class GetTaxForecastsHandler : IRequestHandler<GetTaxForecastsQuery, GetTaxForecastsResult>
{
    private readonly ITaxForecastsRepository _taxForecastsRepository;

    public GetTaxForecastsHandler(ITaxForecastsRepository taxForecastsRepository)
    {
        _taxForecastsRepository = taxForecastsRepository;
    }

    public async Task<GetTaxForecastsResult> Handle(GetTaxForecastsQuery request, CancellationToken cancellationToken)
    {
        var taxForecasts = await _taxForecastsRepository.GetTaxForecastsAsync(request, cancellationToken);

        return new()
        {
            TaxForecasts = taxForecasts,
        };
    }
}
