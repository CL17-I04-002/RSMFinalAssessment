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
    public class OrdersConfiguration : IEntityTypeConfiguration<Orders>
    {
        public void Configure(EntityTypeBuilder<Orders> builder)
        {
            builder.ToTable(nameof(Orders));

            builder.HasKey(o => o.OrderID);

            builder.Property(o => o.OrderDate).HasColumnType("datetime");
            builder.Property(o => o.RequiredDate).HasColumnType("datetime");
            builder.Property(o => o.ShippedDate).HasColumnType("datetime");

            builder.Property(o => o.Freight).HasColumnType("money");

            builder.Property(o => o.ShipName).HasMaxLength(40);
            builder.Property(o => o.ShipAddress).HasMaxLength(60);
            builder.Property(o => o.ShipCity).HasMaxLength(15);
            builder.Property(o => o.ShipRegion).HasMaxLength(15);
            builder.Property(o => o.ShipPostalCode).HasMaxLength(10);
            builder.Property(o => o.ShipCountry).HasMaxLength(15);

            // Relationships
            builder.HasOne(o => o.Customer)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.CustomerID);

            builder.HasOne(o => o.Employee)
                .WithMany(e => e.Orders)
                .HasForeignKey(o => o.EmployeeID)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(o => o.Shipper)
                .WithMany(s => s.Orders)
                .HasForeignKey(o => o.ShipVia);
        }
    }
}
