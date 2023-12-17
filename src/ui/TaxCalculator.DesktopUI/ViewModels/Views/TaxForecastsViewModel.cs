using MediatR;
using TaxCalculator.Application.TaxForecasts.Commands.CreateTaxForecast;
using TaxCalculator.Domain.Entities;

namespace TaxCalculator.DesktopUI.ViewModels.Views;

public sealed class TaxForecastsViewModel : ViewModelBase
{
    private readonly ISender _sender;

    public TaxForecastsViewModel(ISender sender)
    {
        _sender = sender;
    }

    public void SaveForecastEventHandler(TaxForecast taxForecast)
    {
        _sender.Send(new CreateTaxForecastCommand()
        {
            Title = taxForecast.Title
        }).Wait();
    }
}
