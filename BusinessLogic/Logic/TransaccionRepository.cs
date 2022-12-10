using BusinessLogic.Data;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Logic
{
    public class TransaccionRepository : ITransaccionRepository
    {
        private readonly AtmDbContext _context;
        //private readonly IHttpContextAccessor _httpContextAccessor;

        public TransaccionRepository(AtmDbContext context)
        {
            _context = context;
            //_httpContextAccessor = httpContextAccessor;
        }

        public async Task<IReadOnlyList<Transaccion>> GetTransaccionesByCuenta(ulong cuenta)
        {
            
            //var cuenta = _httpContextAccessor.HttpContext.User?.Claims?.FirstOrDefault(c => c.Type == ClaimTypes.Name)?
            var idCuenta = await _context.Cuenta.FirstOrDefaultAsync(c => c.Tarjeta == cuenta);
            if (idCuenta == null)
            {
                throw new Exception("ooops");
            }
            return await _context.Transaccion.Where(t => t.IdCuenta == idCuenta.Id).ToListAsync();

        }


        public async Task<Transaccion> RegistrarRetiTrans(ulong cuenta, decimal monto)
        {
            var idCuenta = await _context.Cuenta.FirstOrDefaultAsync(c => c.Tarjeta == cuenta);
            if (idCuenta == null)
            {
                throw new Exception("ooops");
            }
            if (idCuenta.Bloqueada)
            {
                throw new Exception("Cuenta bloqueada");
            }
            if(monto <= idCuenta.Saldo)
            {
                idCuenta.Saldo = idCuenta.Saldo - monto;

                var tran = new Transaccion
                {
                    IdCuenta = idCuenta.Id,
                    IdTipTrans = 2,
                    Monto = monto,
                    Fecha = DateTime.Now
                };

                 _context.Transaccion.Add(tran);

                await _context.SaveChangesAsync();
                return tran;
            }
            else
            {
                throw new Exception("El saldo es insuficiente.");
            }
            
        }

    }
}
