using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TaxCalculator.Infrastructure;
using TaxCalculator.Infrastructure.Data;

namespace TaxCalculator.Application.FunctionalTests;

[TestFixture]
public abstract class HostFixture
{
    protected IHost _host;

    [SetUp]
    public void SetUp()
    {
        _host = Host.CreateDefaultBuilder()
            .ConfigureServices((hostContext, services) =>
            {
                services.AddApplicationServices();
                services.AddInfrastructureServices();
                services.AddTestServices();
            }).Build();

        using var scope = _host.Services.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        DatabaseInitializer.SeedDatabaseAsync(db).Wait();
    }

    [TearDown]
    public void TearDown()
    {
        _host.Dispose();
    }

    public async Task<TResult> SendAsync<TResult>(IRequest<TResult> request)
    {
        using var scope = _host.Services.CreateScope();

        var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();

        return await mediator.Send(request);
    }
}
