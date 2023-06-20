
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
    public class SaldoDiarioService : ISaldoDiarioService
    {
        private readonly ILancamentoRepository _lancamentoRepository;

        public SaldoDiarioService(ILancamentoRepository lancamentoRepository)
        {
            _lancamentoRepository = lancamentoRepository;
        }

        public async Task<decimal> ObterSaldoDiario(DateTime data)
        {  
            var lancamentos = await _lancamentoRepository.GetLancamentosByDate(data);

            decimal saldoDiario = 0;

            foreach (var lancamento in lancamentos)
            {
                if (lancamento.Tipo == TipoLancamento.Debito)
                    saldoDiario -= lancamento.Valor;
                else if (lancamento.Tipo == TipoLancamento.Credito)
                    saldoDiario += lancamento.Valor;
            }

            return saldoDiario;           
        }
    }
}
