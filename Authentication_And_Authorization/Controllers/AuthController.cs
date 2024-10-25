using Authentication_And_Authorization.Models;
using Authentication_And_Authorization.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Authentication_And_Authorization.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService autheService)
        {
            _authService = autheService;
        }

        [HttpPost("addUser")]
        public ActionResult AddUser([FromBody] User user)
        { 
            var entity = _authService.AddUser(user);
            return Ok(entity);
        }

        [HttpPost]
        public ActionResult Login([FromBody] LoginRequest loginRequest)
        { 
            var result = _authService.Login(loginRequest);
            return Ok(result);
        }
    }
}
