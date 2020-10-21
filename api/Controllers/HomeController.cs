using API.Repositories;
using API.Services;
using APICatalogo.Modelos;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers
{
    public class HomeController : ControllerBase
    {
        [HttpPost]
        [Route("login")]
        public ActionResult<dynamic> Authenticate([FromBody]Usuario model)
        {
            // Recupera o usuário
            var user = UserRepository.Get(model.Nome, model.Password);

            // Verifica se o usuário existe
            if (user == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            // Gera o Token
            var token = TokenService.GenerateToken(user);

            // Oculta a senha
            user.Password = "";
            
            // Retorna os dados
            return new
            {
                user = user,
                token = token
            };
        }

        // Tests onlys

        [HttpGet]
        [Route("anonymous")]
        [AllowAnonymous]
        public string Anonymous() => "Anônimo";

        [HttpGet]
        [Route("auth")]
        [Authorize]
        public string Authenticated() => String.Format("Autenticado - {0}", User.Identity.Name);

        [HttpGet]
        [Route("user")]
        [Authorize(Roles = "USER, ADMIN")]
        public string Usuario() => "Usuario";

        [HttpGet]
        [Route("admin")]
        [Authorize(Roles = "ADMIN")]
        public string Admin() => "Admin";
    }
}