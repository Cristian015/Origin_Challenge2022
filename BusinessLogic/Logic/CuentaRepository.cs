using BusinessLogic.Data;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Logic
{
    public class CuentaRepository : ICuentaRepository
    {
        private readonly AtmDbContext _context;

        public static int cont  { get; set; }

        public CuentaRepository(AtmDbContext context)
        {
            _context = context;
        }

        public async Task<Boolean> GetCuentaByCuentaAsync(ulong cuenta, int pass)
        {
            var cuent = await _context.Cuenta.FirstOrDefaultAsync(c => c.Tarjeta == cuenta);
            
            if (cuent == null)
            {
                throw new Exception("Credenciales incorrectas");
            }
            if (cuent.Bloqueada)
            {
                throw new Exception("Cuenta bloqueada");
            }
            if(cuent.Pin != pass)
            {
                cont++;
                if(cont >= 4)
                {
                    cuent.Bloqueada = true;
                    await _context.SaveChangesAsync();
                    throw new Exception("Tarjeta bloquada");
                }
                return false;
                
                
            }
            return true;
        }
    }
}
