using ControleEpi.Model;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace ControleEpi.Data
{
    public class AppdbContext:DbContext
    {
        public AppdbContext(DbContextOptions<AppdbContext> ops):base(ops) { }
        public DbSet<Epi> epis { get; set; }
        public DbSet<Colaborador> colaboradors { get; set; }
    }
}
