using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TaxCalculator.Application.Common.Repositories;
using TaxCalculator.Infrastructure.Data;
using TaxCalculator.Infrastructure.Data.Interceptors;
using TaxCalculator.Infrastructure.Data.Repositories;

namespace TaxCalculator.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.AddInterceptors(new EntityChangeInterceptor());

            options.UseInMemoryDatabase("TaxCalculatorDb");
        });

        services.AddTransient<ITaxForecastsRepository, TaxForecastRepository>();

        return services;
    }
}