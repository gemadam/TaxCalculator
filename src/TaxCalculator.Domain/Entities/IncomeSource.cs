using TaxCalculator.Domain.Common;

namespace TaxCalculator.Domain.Entities;

public sealed record IncomeSource : EntityBase
{
    public string Name { get; init; } = string.Empty;
    public decimal Amount { get; init; }
}