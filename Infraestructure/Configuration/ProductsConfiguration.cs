using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Configuration
{
    public class ProductsConfiguration : IEntityTypeConfiguration<Products>
    {
        public void Configure(EntityTypeBuilder<Products> builder)
        {
            builder.ToTable(nameof(Products));

            builder.HasKey(p => p.ProductID);

            builder.Property(p => p.ProductName).HasMaxLength(40);
            builder.Property(p => p.QuantityPerUnit).HasMaxLength(20);
            builder.Property(p => p.UnitPrice).HasColumnType("money");
            builder.Property(p => p.UnitsInStock).HasColumnType("smallint");
            builder.Property(p => p.UnitsOnOrder).HasColumnType("smallint");
            builder.Property(p => p.ReorderLevel).HasColumnType("smallint");
        }
    }
}
