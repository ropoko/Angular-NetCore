using API.Contexto;
using APICatalogo.Contexto;
using APICatalogo.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace APICatalogo.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly ContextMySql _context;
        
        public UsuariosController(ContextMySql context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Usuario>> Get()
        {
            return _context.Usuarios.AsNoTracking().ToList();
        }

        [HttpGet("{id}", Name = "ObterUsuario")]
        public ActionResult<Usuario> Get(int id)
        {
            var Usuario = _context.Usuarios.AsNoTracking().FirstOrDefault(p => p.IDUsuario == id);

            if (Usuario == null)
            {
                return NotFound();
            }
            else
            {
                return Usuario;
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody] Usuario Usuario)
        {
            var user = _context.Usuarios.SingleOrDefault(x => x.Nome == Usuario.Nome);
            if (user != null)
            {
                return Ok(new {nome = "já existente"});
            }

            _context.Usuarios.Add(Usuario);
            _context.SaveChanges();

            return new CreatedAtRouteResult("ObterUsuario", new { id = Usuario.IDUsuario }, Usuario);
        }


        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Usuario Usuario)
        {
            if (id != Usuario.IDUsuario)
            {
                return BadRequest();
            }

            _context.Entry(Usuario).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult<Usuario> Delete(int id)
        {
            var Usuario = _context.Usuarios.Find(id);

            if (Usuario == null)
            {
                return NotFound();
            }

            _context.Usuarios.Remove(Usuario);
            _context.SaveChanges();
            return Usuario;
        }


    }
}
