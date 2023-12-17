using System.Windows.Controls;
using TaxCalculator.Domain.Entities;

namespace TaxCalculator.DesktopUI.Views.Views;

public delegate void TaxForecastSaveEvent(TaxForecast taxForecast);

/// <summary>
/// Interaction logic for CreateTaxForecastView.xaml
/// </summary>
public partial class CreateTaxForecastView : Page
{
    public event TaxForecastSaveEvent OnTaxForecastSaveClick;

    public CreateTaxForecastView()
    {
        InitializeComponent();
    }
}
