using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TaxCalculator.Application;
using TaxCalculator.Application.TaxForecasts.Queries.GetTaxForecasts;
using TaxCalculator.ConsoleUI;
using TaxCalculator.Infrastructure;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        services.AddApplicationServices();
        services.AddInfrastructureServices();
        services.AddConsoleServices();
    }).Build();

var mediator = host.Services.GetRequiredService<IMediator>();

var result = await mediator.Send(new GetTaxForecastsQuery());

Console.WriteLine("Hello, World!");