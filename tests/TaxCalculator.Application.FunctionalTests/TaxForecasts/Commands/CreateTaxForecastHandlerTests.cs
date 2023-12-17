using FluentAssertions;
using System.ComponentModel.DataAnnotations;
using TaxCalculator.Application.TaxForecasts.Commands.CreateTaxForecast;

namespace TaxCalculator.Application.FunctionalTests.TaxForecasts.Commands;

public class CreateTaxForecastHandlerTests : HostFixture
{
    [Test]
    public async Task EmptyForecastTitle_ShouldThrowValidationException()
    {
        // Arrange
        var query = new CreateTaxForecastCommand()
        {
            Title = string.Empty
        };

        // Act
        var action = () => SendAsync(query);

        // Assert
        await action.Should().ThrowAsync<ValidationException>();
    }
}