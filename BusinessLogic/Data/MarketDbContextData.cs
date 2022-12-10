using Core.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Data
{
    public class MarketDbContextData
    {
        public static async Task CargarDataAsync(AtmDbContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                if (!context.Cuenta.Any())
                {
                    var cuenta = new Cuenta
                    {
                        Tarjeta = 1234567890123456,
                        Pin = 1234,
                        Bloqueada = false,
                        Saldo = 1000,
                        FecVenc = new DateTime(2023 - 12 - 12),
                    };

                    context.Cuenta.Add(cuenta);
                    await context.SaveChangesAsync();
                }
                
                if (!context.TipTrans.Any())
                {
                    var tiptrans = new TipTrans
                    { Nombre = "Balance" };
                    var tiptrans2 = new TipTrans
                    { Nombre = "Retiro" };

                    context.TipTrans.Add(tiptrans);
                    await context.SaveChangesAsync();

                    context.TipTrans.Add(tiptrans2);
                    await context.SaveChangesAsync();
                }

                if (!context.Transaccion.Any())
                {
                    var tran = new Transaccion
                    {
                        IdCuenta = 1,
                        IdTipTrans = 1,
                        Fecha = DateTime.Now
                    };
                    var tran2 = new Transaccion
                    {
                        IdCuenta = 1,
                        IdTipTrans = 2,
                        Monto = 10,
                        Fecha = DateTime.Now
                    };

                    context.Transaccion.Add(tran);
                    await context.SaveChangesAsync();

                    context.Transaccion.Add(tran2);
                    await context.SaveChangesAsync();
                }

            }
            catch (Exception e)
            {

                var logger = loggerFactory.CreateLogger<AtmDbContext>();
                logger.LogError(e.Message);
            }
        }
    }
}
