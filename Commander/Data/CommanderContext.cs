using Commander.Models;
using Microsoft.EntityFrameworkCore;

namespace Commander.Data
{
    public class CommanderContext :DbContext
    {
        public CommanderContext(DbContextOptions<CommanderContext> opt) : base(opt)
        {
            
        }

        public DbSet<Especies> Especies{ get; set; }
        public DbSet<Arvores> Arvores{ get; set; }
        public DbSet<GrupoArvores> GrupoArvores{ get; set; }
        public DbSet<Colheita> Colheita{ get; set; }
    }
}