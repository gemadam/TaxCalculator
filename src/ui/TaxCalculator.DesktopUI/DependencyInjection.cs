using Microsoft.Extensions.DependencyInjection;
using System;
using TaxCalculator.DesktopUI.Common;
using TaxCalculator.DesktopUI.ViewModels.Views;
using TaxCalculator.DesktopUI.Views.Views;
using TaxCalculator.DesktopUI.Views.Windows;

namespace TaxCalculator.DesktopUI;

public static class DependencyInjection
{
    public static IServiceCollection AddDesktopUIServices(this IServiceCollection services)
    {
        services.AddSingleton<MainWindow>();
        services.AddView<TaxForecastsView, TaxForecastsViewModel>();
        services.AddView<CreateTaxForecastView>();

        return services;
    }

    public static IServiceCollection AddWindow<TWindow, TViewModelInterface, TViewModel>(this IServiceCollection services)
        where TWindow : class
        where TViewModelInterface : class
        where TViewModel : class, TViewModelInterface
    {
        services.AddSingleton<TWindow>();
        services.AddScoped<TViewModelInterface, TViewModel>();

        services.AddSingleton<Func<TWindow>>(x => () => x.GetRequiredService<TWindow>());
        services.AddSingleton<IAbstractFactory<TWindow>, AbstractFactory<TWindow>>();

        return services;
    }

    public static IServiceCollection AddView<TView>(this IServiceCollection services)
        where TView : class
    {
        services.AddTransient<TView>();

        services.AddSingleton<Func<TView>>(x => () => x.GetRequiredService<TView>());
        services.AddSingleton<IAbstractFactory<TView>, AbstractFactory<TView>>();

        return services;
    }

    public static IServiceCollection AddView<TView, TViewModel>(this IServiceCollection services)
        where TView : class
        where TViewModel : class
    {
        services.AddTransient<TView>();
        services.AddScoped<TViewModel>();

        services.AddSingleton<Func<TView>>(x => () => x.GetRequiredService<TView>());
        services.AddSingleton<IAbstractFactory<TView>, AbstractFactory<TView>>();

        return services;
    }
}