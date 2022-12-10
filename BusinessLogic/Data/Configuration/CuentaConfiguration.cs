using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Data.Configuration
{
    public class CuentaConfiguration : IEntityTypeConfiguration<Cuenta>
    {
        public void Configure(EntityTypeBuilder<Cuenta> builder)
        {
            builder.Property(c => c.Tarjeta).IsRequired().HasColumnType("numeric");
            builder.Property(c => c.Pin).IsRequired().HasColumnType("numeric");
            builder.Property(c => c.Saldo).HasColumnType("decimal(18,2)");
        }
    }
}
