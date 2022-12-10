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
    public class TransaccionConfiguration : IEntityTypeConfiguration<Transaccion>
    {
        public void Configure(EntityTypeBuilder<Transaccion> builder)
        {
            builder.Property(t => t.Monto).HasColumnType("decimal(18,2)");
            builder.HasOne(c => c.Cuenta).WithMany().HasForeignKey(t => t.IdCuenta);
            builder.HasOne(tt => tt.TipTrans).WithMany().HasForeignKey(t => t.IdTipTrans);
        }
    }
}
