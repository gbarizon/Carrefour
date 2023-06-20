using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlaucioBP.FluxoDeCaixaDiario.Aplicacao.Interfaces
{
    // Interface para o serviço do saldo diário consolidado
    public interface ISaldoDiarioService
    {
        Task<decimal> ObterSaldoDiario(DateTime data);
    }
}
