using TaxCalculator.Domain.Common;

namespace TaxCalculator.Domain.Entities;

public sealed record TaxForecast : EntityBase
{
    public string Title { get; init; } = string.Empty;
    public IList<IncomeSource> IncomeSources { get; init; } = new List<IncomeSource>();

    public static TaxForecast Create(string title)
        => new()
        {
            Title = title,
            IncomeSources = new List<IncomeSource>()
        };
}
