using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaxCalculator.Domain.Entities;

namespace TaxCalculator.Infrastructure.Data.Configurations;

public sealed class TaxForecastConfiguration : IEntityTypeConfiguration<TaxForecast>
{
    public void Configure(EntityTypeBuilder<TaxForecast> builder)
    {
        builder.Property(t => t.Title)
            .HasMaxLength(200)
            .IsRequired();

        builder
            .HasMany(b => b.IncomeSources);
    }
}
