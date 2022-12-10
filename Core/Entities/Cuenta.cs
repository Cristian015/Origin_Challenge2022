using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Cuenta : ClaseBase
    {
        [StringLength(16, ErrorMessage ="El num ingresado es incorrecto.")]
        public ulong Tarjeta { get; set; }

        [StringLength(4, ErrorMessage = "El num ingresado es incorrecto.")]
        public int Pin { get; set; }
        public bool Bloqueada { get; set; }
                
        public decimal Saldo { get; set; }
        public DateTime FecVenc { get; set; }
    }
}
