using TaxCalculator.Domain.Constants;

namespace TaxCalculator.Application.Common.Models;

public abstract record PaginatedQuery
{
    public int PageNumber { get; init; } = PaginationDefaultValues.DefaultPageNumber;
    public int PageSize { get; init; } = PaginationDefaultValues.DefaultPageSize;
}
