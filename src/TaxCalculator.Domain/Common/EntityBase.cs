namespace TaxCalculator.Domain.Common;

public abstract record EntityBase
{
    public long Id { get; set; }

    public DateTimeOffset CreatedOn { get; set; }

    public DateTimeOffset ModifiedOn { get; set; }
}
