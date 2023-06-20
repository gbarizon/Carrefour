using GlaucioBP.FluxoDeCaixaDiario.Aplicacao.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Globalization;
using System.Threading.Tasks;

namespace GlaucioBP.FluxoDeCaixaDiario.API2.Controller
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

        [HttpGet, Route("ObterSaldoDiario")]
        [SwaggerOperation("Obtém o saldo diário consolidado")]
        public async Task<IActionResult> ObterSaldoDiario(string dataParam)
        {
            CultureInfo ptbr = new CultureInfo("pt-BR");
            DateTime data;

            if (!DateTime.TryParseExact(dataParam, "dd/MM/yyyy", ptbr,
                              DateTimeStyles.None, out data))
                
                return BadRequest("Data Inválida");


            var saldoDiario = await _saldoDiarioService.ObterSaldoDiario(data);

            return Ok(saldoDiario);
        }
    }
}
