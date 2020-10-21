using System;
using APICatalogo.Modelos;
using Microsoft.EntityFrameworkCore;
using System.Data.OleDb;
using Oracle.ManagedDataAccess.Client;

namespace API.Contexto
{
    public class ContextOracle : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }

        public ContextOracle(DbContextOptions<ContextOracle> op) : base(op)
        {
        }
    }
}
