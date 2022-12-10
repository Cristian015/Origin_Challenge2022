using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface ITransaccionRepository
    {
        Task<IReadOnlyList<Transaccion>> GetTransaccionesByCuenta(ulong cuenta);
        Task<Transaccion> RegistrarRetiTrans(ulong cuenta, decimal monto);
    }
}
