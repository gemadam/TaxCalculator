using System.Windows.Controls;
using TaxCalculator.DesktopUI.Common;
using TaxCalculator.DesktopUI.ViewModels.Views;
using TaxCalculator.Domain.Entities;

namespace TaxCalculator.DesktopUI.Views.Views
{
    /// <summary>
    /// Interaction logic for TaxForecastsView.xaml
    /// </summary>
    public partial class TaxForecastsView : Page
    {
        private readonly CreateTaxForecastView _createTaxForecastView;

        public TaxForecastsViewModel ViewModel
        {
            get => (TaxForecastsViewModel)DataContext;
            set => DataContext = value;
        }

        public TaxForecastsView(TaxForecastsViewModel viewModel,
            IAbstractFactory<CreateTaxForecastView> createTaxForecastViewFactory)
        {
            ViewModel = viewModel;
            _createTaxForecastView = createTaxForecastViewFactory.Create();
            _createTaxForecastView.OnTaxForecastSaveClick += SaveForecastEventHandler;

            InitializeComponent();
        }

        private void AddForecastButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            ViewFrame.Content = _createTaxForecastView;
        }

        public void SaveForecastEventHandler(TaxForecast taxForecast)
        {
            ViewModel.SaveForecastEventHandler(taxForecast);

            ViewFrame.Content = null;
            ViewFrame.NavigationService.RemoveBackEntry();
        }
    }
}
