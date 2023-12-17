using System.Windows;
using TaxCalculator.DesktopUI.Common;
using TaxCalculator.DesktopUI.Views.Views;

namespace TaxCalculator.DesktopUI.Views.Windows;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow(IAbstractFactory<TaxForecastsView> abstractFactory)
    {
        InitializeComponent();

        ViewFrame.Content = abstractFactory.Create();
    }
}
