using Microsoft.Extensions.DependencyInjection;

namespace TaxCalculator.ConsoleUI;

public static class DependencyInjection
{
    public static IServiceCollection AddConsoleServices(this IServiceCollection services)
    {
        return services;
    }
}