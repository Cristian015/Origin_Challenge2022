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
    public class CuentaController : ControllerBase
    {

        private readonly ICuentaRepository _cuentaRepository;

        public CuentaController(ICuentaRepository cuentaRepository)
        {
            _cuentaRepository = cuentaRepository;
        }


        [HttpPost("login")]
        public async Task<ActionResult<Boolean>> Login(ulong cuent, int pass)
        {
            return await _cuentaRepository.GetCuentaByCuentaAsync(cuent, pass);
            
        }

    }
}
