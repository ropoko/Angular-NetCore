using APICatalogo.Modelos;
using Microsoft.EntityFrameworkCore;

namespace API.Contexto
{
    public class ContextSqlServer : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }

        public ContextSqlServer(DbContextOptions<ContextSqlServer> op) : base(op)
        {
        }
    }
}
