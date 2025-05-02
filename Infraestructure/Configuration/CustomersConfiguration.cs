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
    public class CustomersConfiguration : IEntityTypeConfiguration<Customers>
    {
        public void Configure(EntityTypeBuilder<Customers> builder)
        {
            builder.ToTable(nameof(Customers));

            builder.HasKey(c => c.CustomerID);

            builder.Property(c => c.CustomerID)
                .HasColumnType("nchar(5)");

            builder.Property(c => c.CompanyName)
                .HasMaxLength(40)
                .HasColumnType("nvarchar(40)");

            builder.Property(c => c.ContactName)
                .HasMaxLength(30)
                .HasColumnType("nvarchar(30)");

            builder.Property(c => c.ContactTitle)
                .HasMaxLength(30)
                .HasColumnType("nvarchar(30)");

            builder.Property(c => c.Address)
                .HasMaxLength(60);

            builder.Property(c => c.City)
                .HasMaxLength(15);

            builder.Property(c => c.Region)
                .HasMaxLength(15);

            builder.Property(c => c.PostalCode)
                .HasMaxLength(10);

            builder.Property(c => c.Country)
                .HasMaxLength(15);

            builder.Property(c => c.Phone)
                .HasMaxLength(24);

            builder.Property(c => c.Fax)
                .HasMaxLength(24);
        }
    }
}
