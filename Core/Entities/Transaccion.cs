using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Transaccion : ClaseBase
    {
        public int IdCuenta { get; set; }
        public Cuenta Cuenta { get; set; }
        public int IdTipTrans { get; set; }
        public TipTrans TipTrans { get; set; }
        public decimal Monto { get; set; }
        public DateTime Fecha { get; set; }
    }
}
