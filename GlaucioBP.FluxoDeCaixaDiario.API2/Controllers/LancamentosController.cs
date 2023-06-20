using AutoMapper;
using GlaucioBP.FluxoDeCaixaDiario.Aplicacao.DTOs;
using GlaucioBP.FluxoDeCaixaDiario.Aplicacao.Interfaces;
using GlaucioBP.FluxoDeCaixaDiario.Dominio.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GlaucioBP.FluxoDeCaixaDiario.API2.Controllers
{
    // Controlador para o controle de lançamentos
    [ApiController]
    [Route("api/lancamentos")]
    [Produces("application/json")]
    public class LancamentosController : ControllerBase
    {
        private readonly ILancamentoService _lancamentoService;
        public readonly IMapper _mapper;

        public LancamentosController(ILancamentoService lancamentoService, IMapper mapper)
        {
            _lancamentoService = lancamentoService;
            _mapper = mapper;
        }

        [HttpPost, Route("CriarLancamento")]        
        public async Task<IActionResult> CriarLancamento([FromBody] LancamentoDTO lancamentoDTO)
        {
            var lancamento = _mapper.Map<Lancamento>(lancamentoDTO);

            await _lancamentoService.CriarLancamento(lancamento);

            return Ok();
        }
    }
}
