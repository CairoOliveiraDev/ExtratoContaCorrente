using ExtratoContaCorrente.Model;
using System.Collections.Generic;
using
using Microsoft.EntityFrameworkCore;

namespace ExtratoContaCorrente.Context
{
    public class LançamentoContext : DbContext
    {
        public LançamentoContext(DbContextOptions<LançamentoContext> options)
        : base(options)
        {
        }

        public DbSet<Lançamento> Lançamentos { get; set; }
    }
}
