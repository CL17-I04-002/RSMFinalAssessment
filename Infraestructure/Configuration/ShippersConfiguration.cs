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
    public class ShippersConfiguration : IEntityTypeConfiguration<Shippers>
    {
        public void Configure(EntityTypeBuilder<Shippers> builder)
        {
            builder.ToTable(nameof(Shippers));

            builder.HasKey(s => s.ShipperID);

            builder.Property(s => s.CompanyName)
                .HasMaxLength(40)
                .IsRequired();

            builder.Property(s => s.Phone)
                .HasMaxLength(24);
        }
    }
}
