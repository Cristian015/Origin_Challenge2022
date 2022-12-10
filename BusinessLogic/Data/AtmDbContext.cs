using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Data
{
    public class AtmDbContext : DbContext
    {

        public AtmDbContext(DbContextOptions<AtmDbContext> options) : base(options) { }

        public DbSet<Cuenta> Cuenta { get; set; }
        public DbSet<TipTrans> TipTrans { get; set; }
        public DbSet<Transaccion> Transaccion { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}
