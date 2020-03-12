using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Repositories;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {        
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody]User model)
        {
            //Get user
            var user = UserRepository.Get(model.Username, model.Password);

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
    }
}
