﻿using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products");

        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");

        builder.Property(u => u.Title).IsRequired().HasMaxLength(50);
        // builder.Property(u => u.Price).IsRequired();
        builder.Property(u => u.Description).IsRequired().HasMaxLength(100);
        builder.Property(u => u.Category).IsRequired().HasMaxLength(50);
        builder.Property(u => u.Image).HasMaxLength(100);
    }
}
