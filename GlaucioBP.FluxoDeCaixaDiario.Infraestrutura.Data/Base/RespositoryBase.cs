using GlaucioBP.FluxoDeCaixaDiario.Dominio.Interfaces.Repositories;
using GlaucioBP.FluxoDeCaixaDiario.Infraestrutura.Data.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GlaucioBP.FluxoDeCaixaDiario.Infraestrutura.Data.Base
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected FluxoDeCaixaDiarioContexto RepositoryContext { get; set; }
        public RepositoryBase(FluxoDeCaixaDiarioContexto repositoryContext)
        {
            RepositoryContext = repositoryContext;
        }
        public IQueryable<T> FindAll() => RepositoryContext.Set<T>().AsNoTracking();
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression) =>
            RepositoryContext.Set<T>().Where(expression).AsNoTracking();
       
    }
}
