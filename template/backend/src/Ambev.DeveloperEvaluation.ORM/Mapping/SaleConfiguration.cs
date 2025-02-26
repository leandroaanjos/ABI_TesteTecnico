using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class SaleConfiguration : IEntityTypeConfiguration<Sale>
{
    public void Configure(EntityTypeBuilder<Sale> builder)
    {
        builder.ToTable("Sales");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");

        builder.Property(x => x.SaleNumber).IsRequired().HasMaxLength(50);
        builder.Property(x => x.Customer).IsRequired().HasMaxLength(50);
        builder.Property(x => x.Branch).IsRequired().HasMaxLength(50);
        builder.Property(x => x.TotalAmount).HasColumnType("numeric(18,2)");

        builder.HasMany(s => s.Items).WithOne(si => si.Sale).HasForeignKey(x => x.SaleId).OnDelete(DeleteBehavior.Cascade);
    }
}
