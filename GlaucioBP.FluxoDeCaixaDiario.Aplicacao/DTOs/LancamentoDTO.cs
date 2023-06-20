
using GlaucioBP.FluxoDeCaixaDiario.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlaucioBP.FluxoDeCaixaDiario.Aplicacao.DTOs
{
    public class LancamentoDTO
    {
        public decimal Valor { get; set; }
        public TipoLancamento Tipo { get; set; }
        public DateTime Data { get; set; }

        public LancamentoDTO() 
        { 
            
        }
    }
}
