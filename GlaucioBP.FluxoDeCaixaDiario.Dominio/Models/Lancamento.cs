using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlaucioBP.FluxoDeCaixaDiario.Dominio.Models
{
    public class Lancamento
    {
        public long Id { get; set; }
        public decimal Valor { get; set; }
        public TipoLancamento Tipo { get; set; }
        public DateTime Data { get; set; }
    }

    public enum TipoLancamento
    {
        Debito,
        Credito
    }
}
