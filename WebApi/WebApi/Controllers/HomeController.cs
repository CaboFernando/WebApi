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
        private readonly UserService _userService;

        public HomeController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody]User model)
        {
            //Get user
            //var user = UserRepository.Get(model.Username.ToLower(), model.Password); // <== Get using data in List
            var userDb = _userService.Get(model.Username, model.Password); // <== Get using data base connection

            //Verify if user exist
            if (userDb == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            //Generating token
            var token = TokenService.GenerateToken(userDb);

            //Password hide
            userDb.Password = "";

            //Data return
            return new
            {
                user = userDb,
                token = token
            };
        }

        [HttpGet]
        [Route("anonymous")]
        [AllowAnonymous]
        //public string Anonymous() => "Este é o retorno do método que todos podem acessar"; // <== Return string
        public ActionResult Anonymous() => Ok(Json("Este é o retorno do método que todos podem acessar")); // <== Return Json

        [HttpGet]
        [Route("authenticated")]
        [Authorize]
        //public string Authenticated() => String.Format("Este é o retorno autenticado - {0}", User.Identity.Name); // <== Return string
        public ActionResult Authenticated() => Ok(Json("Este é o retorno autenticado - " + User.Identity.Name)); // <== Return Json

        [HttpGet]
        [Route("dev")]
        [Authorize(Roles = "DevMaster,DevBack")]
        //public string Developer() => "Este é o retorno autenticado para quem faz parte do perfil de Desenvolvedor"; // <== Return string
        public ActionResult Developer() => Ok(Json("Este é o retorno autenticado para quem faz parte do perfil de Desenvolvedor")); // <== Return Json

        [HttpGet]
        [Route("owner")]
        [Authorize(Roles = "Owner")]
        //public string Owner() => "Este é o retorno autenticado para quem faz parte do perfil de Dono"; // <== Return string
        public ActionResult Owner() => Ok(Json("Este é o retorno autenticado para quem faz parte do perfil de Dono")); // <== Return Json

    }
}
