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
    }
}
