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
    public class EmployeesConfiguration : IEntityTypeConfiguration<Employees>
    {
        public void Configure(EntityTypeBuilder<Employees> builder)
        {
            builder.ToTable(nameof(Employees));

            builder.HasKey(e => e.EmployeeID);

            builder.Property(e => e.EmployeeID)
                .HasColumnName("EmployeeID");

            builder.Property(e => e.LastName)
                .HasMaxLength(20)
                .HasColumnType("nvarchar(20)");

            builder.Property(e => e.FirstName)
                .HasMaxLength(10)
                .HasColumnType("nvarchar(10)");

            builder.Property(e => e.Title)
                .HasMaxLength(30)
                .HasColumnType("nvarchar(30)");

            builder.Property(e => e.TitleOfCourtesy)
                .HasMaxLength(25)
                .HasColumnType("nvarchar(25)");

            builder.Property(e => e.BirthDate)
                .HasColumnType("datetime");

            builder.Property(e => e.HireDate)
                .HasColumnType("datetime");

            builder.Property(e => e.Address)
                .HasMaxLength(60)
                .HasColumnType("nvarchar(60)");

            builder.Property(e => e.City)
                .HasMaxLength(15)
                .HasColumnType("nvarchar(15)");

            builder.Property(e => e.Region)
                .HasMaxLength(15)
                .HasColumnType("nvarchar(15)");

            builder.Property(e => e.PostalCode)
                .HasMaxLength(10)
                .HasColumnType("nvarchar(10)");

            builder.Property(e => e.Country)
                .HasMaxLength(15)
                .HasColumnType("nvarchar(15)");

            builder.Property(e => e.HomePhone)
                .HasMaxLength(24)
                .HasColumnType("nvarchar(24)");

            builder.Property(e => e.Extension)
                .HasMaxLength(4)
                .HasColumnType("nvarchar(4)");

            builder.Property(e => e.Photo)
                .HasColumnType("image");

            builder.Property(e => e.Notes)
                .HasColumnType("ntext");

            builder.Property(e => e.ReportsTo);

            builder.Property(e => e.PhotoPath)
                .HasMaxLength(255)
                .HasColumnType("nvarchar(255)");

            // Optional Relationships
            builder.HasMany(e => e.Orders)
                .WithOne(o => o.Employee)
                .HasForeignKey(o => o.EmployeeID)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
