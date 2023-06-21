namespace GlaucioBP.FluxoDeCaixaDiario.Infraestrutura.Data.DbContexts
{
    using GlaucioBP.FluxoDeCaixaDiario.Dominio.Models;
    using GlaucioBP.FluxoDeCaixaDiario.Infraestrutura.Data.Maps;
    using Microsoft.EntityFrameworkCore;

    public class FluxoDeCaixaDiarioContexto : DbContext
    {
        public DbSet<Lancamento> Lancamentos { get; set; }

        public FluxoDeCaixaDiarioContexto()
        {
                
        }

        public FluxoDeCaixaDiarioContexto(DbContextOptions<FluxoDeCaixaDiarioContexto> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //SQL Server local
                //optionsBuilder.UseSqlServer("Data Source=LAPTOP-521E2CEI\\MSSQLEXPRESS;Database=FdCaixa;Trusted_Connection=True;TrustServerCertificate=True");

                //DOCKER
                optionsBuilder.UseSqlServer("Server=db;Database=FluxoDeCaixaDiarioDB;User=sa;Password=123Mudar!");                
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");
            modelBuilder.ApplyConfiguration(new LancamentoMap());
        }
    }
}
