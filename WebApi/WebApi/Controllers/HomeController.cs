using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Repositories;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/account")]
    public class HomeController : Controller
    {        
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody]User model)
        {
            //Get user
            var user = UserRepository.Get(model.Username.ToLower(), model.Password);

            //Verify if user exist
            if (user == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            //Generating token
            var token = TokenService.GenerateToken(user);

            //Password hide
            user.Password = "";

            //Data return
            return new
            {
                user = user,
                token = token
            };
        }

        [HttpGet]
        [Route("anonymous")]
        [AllowAnonymous]
        public string Anonymous() => "Este é o retorno do método que todos podem acessar";

        [HttpGet]
        [Route("authenticated")]
        [Authorize]
        public string Authenticated() => String.Format("Este é o retorno autenticado - {0}", User.Identity.Name);

        [HttpGet]
        [Route("dev")]
        [Authorize(Roles = "DevMaster,DevBack")]
        public string Developer() => "Este é o retorno autenticado para quem faz parte do perfil de Desenvolvedor";

        [HttpGet]
        [Route("owner")]
        [Authorize(Roles = "Owner")]
        public string Owner() => "Este é o retorno autenticado para quem faz parte do perfil de Dono";

    }
}
