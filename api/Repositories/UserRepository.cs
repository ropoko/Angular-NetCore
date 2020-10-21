using System.Collections.Generic;
using System.Linq;
using APICatalogo.Modelos;

namespace API.Repositories
{
    public static class UserRepository
    {
        public static Usuario Get(string username, string password)
        {
            var users = new List<Usuario>();
            users.Add(new Usuario { IDUsuario = 1, Nome = "admin", Password = "123456", Role = "ADMIN" });
            users.Add(new Usuario { IDUsuario = 2, Nome = "user", Password = "123456", Role = "USER" });
            return users.Where(x => x.Nome.ToLower() == username.ToLower() && x.Password == x.Password).FirstOrDefault();
        }
    }
}