using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using TaxCalculator.Infrastructure.Data;
using TaxCalculator.Infrastructure.Data.Interceptors;

namespace TaxCalculator.Application.FunctionalTests;

public static class DependencyInjection
{
    public static IServiceCollection AddTestServices(this IServiceCollection services)
    {
        services
            .RemoveAll<DbContextOptions<ApplicationDbContext>>()
            .AddDbContext<ApplicationDbContext>(options =>
            {
                options.AddInterceptors(new EntityChangeInterceptor());

                options.UseInMemoryDatabase("TaxCalculatorFunctionalTestsDb");
            });

        return services;
    }
}