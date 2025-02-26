using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class SaleItemConfiguration : IEntityTypeConfiguration<SaleItem>
{
    public void Configure(EntityTypeBuilder<SaleItem> builder)
    {
        builder.ToTable("SaleItem");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");

        builder.Property(x => x.ProductId).HasColumnType("uuid");
        builder.Property(x => x.UnitPrice).HasColumnType("numeric(18,2)");
        builder.Property(x => x.Discount).HasColumnType("numeric(18,2)");
        builder.Property(x => x.TotalAmount).HasColumnType("numeric(18,2)");

        builder.HasOne(x => x.Product).WithOne().OnDelete(DeleteBehavior.NoAction);
    }
}
