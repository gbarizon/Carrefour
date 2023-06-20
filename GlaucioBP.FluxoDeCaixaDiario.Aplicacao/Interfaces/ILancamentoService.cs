using GlaucioBP.FluxoDeCaixaDiario.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlaucioBP.FluxoDeCaixaDiario.Aplicacao.Interfaces
{
    // Interface para o serviço de controle de lançamentos
    public interface ILancamentoService
    {
        Task<int> CriarLancamento(Lancamento lancamento);
    }
}
