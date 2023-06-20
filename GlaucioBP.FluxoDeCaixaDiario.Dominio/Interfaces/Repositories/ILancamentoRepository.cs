using GlaucioBP.FluxoDeCaixaDiario.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlaucioBP.FluxoDeCaixaDiario.Dominio.Interfaces.Repositories
{
    // Interface para o repositório de lançamentos
    public interface ILancamentoRepository 
    
    {
        Task Add(Lancamento lancamento);

        Task<List<Lancamento>> GetLancamentosByDate(DateTime data);
    }
}
