using MediatR;
using System.ComponentModel.DataAnnotations;
using TaxCalculator.Application.Common.Repositories;
using TaxCalculator.Domain.Entities;

namespace TaxCalculator.Application.TaxForecasts.Commands.CreateTaxForecast;

public sealed class CreateTaxForecastHandler : IRequestHandler<CreateTaxForecastCommand, long>
{
    private readonly ITaxForecastsRepository _taxForecastsRepository;

    public CreateTaxForecastHandler(ITaxForecastsRepository taxForecastsRepository)
    {
        _taxForecastsRepository = taxForecastsRepository;
    }

    public async Task<long> Handle(CreateTaxForecastCommand request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(request.Title))
        {
            throw new ValidationException("Tax forecast title cannot be empty");
        }

        var taxForecast = TaxForecast.Create(request.Title);

        taxForecast.Id = await _taxForecastsRepository.CreateTaxForecastsAsync(taxForecast, cancellationToken);

        return taxForecast.Id;
    }
}
