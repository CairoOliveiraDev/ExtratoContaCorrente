using ExtratoContaCorrente.Model;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ExtratoContaCorrente.Context
{
    public class LancamentoContext : DbContext
    {
        public LancamentoContext(DbContextOptions<LancamentoContext> options)
        : base(options)
        {
        }

        public DbSet<Lancamento> Lancamentos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Lancamento>()
                .Property(l => l.Valor)
                // Especifica precisão e escala adequadas
                .HasColumnType("decimal(18, 2)"); 

            

            base.OnModelCreating(modelBuilder);
        }
    }

    
}
