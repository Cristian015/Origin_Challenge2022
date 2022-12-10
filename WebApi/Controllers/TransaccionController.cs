using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransaccionController : ControllerBase
    {
        private readonly ITransaccionRepository _transaccionRepository;

        public TransaccionController (ITransaccionRepository transaccionRepository)
        {
            _transaccionRepository = transaccionRepository;
        }

        [HttpGet("{cuenta}")]
        public async Task<ActionResult<List<Transaccion>>> ConsultaTrans(ulong cuenta)
        {
            var trans = await _transaccionRepository.GetTransaccionesByCuenta(cuenta);
            return Ok(trans);
        }

        [HttpPost("retiro")]
        public async Task<ActionResult<Transaccion>> RetiroTrans(ulong cuenta, decimal monto)
        {
            return await _transaccionRepository.RegistrarRetiTrans(cuenta, monto);
        }
    }
}
