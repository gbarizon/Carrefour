using GlaucioBP.FluxoDeCaixaDiario.Aplicacao.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Threading.Tasks;

namespace GlaucioBP.FluxoDeCaixaDiario.API.Controller
{
    // Controlador para o saldo diário consolidado
    [ApiController]
    [Route("api/saldodiario")]
    [Produces("application/json")]
    public class SaldoDiarioController : ControllerBase
    {
        private readonly ISaldoDiarioService _saldoDiarioService;

        public SaldoDiarioController(ISaldoDiarioService saldoDiarioService)
        {
            _saldoDiarioService = saldoDiarioService;
        }

        [HttpGet("api/ObterSaldoDiario/{data}")]
        //[SwaggerOperation("Obtém o saldo diário consolidado")]
        public async Task<IActionResult> ObterSaldoDiario(DateTime data)
        {
            var saldoDiario = await _saldoDiarioService.ObterSaldoDiario(data);

            return Ok(saldoDiario);
        }
    }
}
