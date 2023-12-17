using System.ComponentModel;

namespace TaxCalculator.DesktopUI.ViewModels;

public abstract class ViewModelBase : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    public void HandlePropertyChange<T>(string propertyName, ref T? property, T? value)
    {
        if (property is null && value is null)
            return;

        if (property is not null && property.Equals(value))
            return;

        if (value is not null && value.Equals(property))
            return;

        property = value;

        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
