using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
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
            var userDb = _userService.Get(model.Username, model.Password);

            if (userDb == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            var token = TokenService.GenerateToken(userDb);

            userDb.Password = "";

            return new
            {
                user = userDb,
                token = token
            };
        }

        [HttpPost]
        [Route("createUser")]
        public void create([FromBody]User user)
        {
            _userService.Create(user);
        }

        [HttpGet]
        [Route("anonymous")]
        [AllowAnonymous]
        public ActionResult Anonymous() => Ok(Json("Este é o retorno do método que todos podem acessar"));

        [HttpGet]
        [Route("authenticated")]
        [Authorize]
        public ActionResult<User> Authenticated()
        {
            var user = _userService.Get();
            return user.Find(x => x.Username == User.Identity.Name);
        }

        [HttpGet]
        [Route("dev")]
        [Authorize(Roles = "DevMaster,DevBack")]
        public ActionResult<List<User>> Developer()
        {
            var users = _userService.Get();
            return users.FindAll(x => (x.Role == "DevMaster" && x.Username == User.Identity.Name) || (x.Role == "DevBack" && x.Username == User.Identity.Name));
        }

        [HttpGet]
        [Route("owner")]
        [Authorize(Roles = "Owner")]
        public ActionResult<List<User>> Owner()
        {
            var user = _userService.Get();
            return user.FindAll(x => x.Username == User.Identity.Name && x.Role == "Owner");
        }

    }
}
