using GlaucioBP.FluxoDeCaixaDiario.Dominio.Interfaces.Repositories;
using GlaucioBP.FluxoDeCaixaDiario.Dominio.Models;
using GlaucioBP.FluxoDeCaixaDiario.Infraestrutura.Data.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlaucioBP.FluxoDeCaixaDiario.Infraestrutura.Data.Repositories
{
    public class LancamentoRepository : ILancamentoRepository
    {
        private readonly FluxoDeCaixaDiarioContexto _dbContext;

        public LancamentoRepository(FluxoDeCaixaDiarioContexto dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Add(Lancamento lancamento)
        {
            await _dbContext.Lancamentos.AddAsync(lancamento);
            await _dbContext.SaveChangesAsync();
        }
        
        public async Task<List<Lancamento>> GetLancamentosByDate(DateTime data)
        {
            var lancamentosDiario = await _dbContext.Lancamentos
               .Where(sd => sd.Data == data).ToListAsync();

            return lancamentosDiario;
        }
    }
}
