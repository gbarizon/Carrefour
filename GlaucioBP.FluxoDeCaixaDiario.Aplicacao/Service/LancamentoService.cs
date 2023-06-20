using GlaucioBP.FluxoDeCaixaDiario.Aplicacao.Interfaces;
using GlaucioBP.FluxoDeCaixaDiario.Dominio.Interfaces.Repositories;
using GlaucioBP.FluxoDeCaixaDiario.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlaucioBP.FluxoDeCaixaDiario.Aplicacao.Service
{
    public class LancamentoService : ILancamentoService
    {
        private readonly ILancamentoRepository _lancamentoRepository;

        public LancamentoService(ILancamentoRepository lancamentoRepository)
        {
            _lancamentoRepository = lancamentoRepository;
        }

        public async Task<int> CriarLancamento(Lancamento lancamento)
        {
            if (lancamento == null) return 0;

            await _lancamentoRepository.Add(lancamento);
            return 1;
        }
    }
}
