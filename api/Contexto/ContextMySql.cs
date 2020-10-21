using APICatalogo.Modelos;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo.Contexto
{
    public class ContextMySql : DbContext
    {
        public ContextMySql(DbContextOptions<ContextMySql> options): base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
    }
}
