using FluentAssertions;
using FluentAssertions.Execution;
using TaxCalculator.Application.TaxForecasts.Queries.GetTaxForecasts;

namespace TaxCalculator.Application.FunctionalTests.TaxForecasts.Queries;

public class GetTaxForecastsHandlerTests : HostFixture
{
    [Test]
    public async Task ShouldReturnPaginatedTaxForecasts()
    {
        // Arrange
        var query = new GetTaxForecastsQuery();

        // Act
        var result = await SendAsync(query);

        // Assert
        using (var scope = new AssertionScope())
        {
            result.TaxForecasts.Should().NotBeNull();

            result.TaxForecasts.PageNumber.Should().Be(query.PageNumber);
            result.TaxForecasts.PageSize.Should().Be(query.PageSize);
            result.TaxForecasts.Items.Should().HaveCountLessThanOrEqualTo(query.PageSize);
        }
    }
}