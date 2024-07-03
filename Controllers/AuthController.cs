using FinOpsAPI.Models;
using FinOpsAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace FinOpsAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : Controller
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] Auth authModel)
        {
            var tokenString = await _authService.Login(authModel);
            if (!string.IsNullOrEmpty(tokenString))
            {
                return Ok(tokenString);
            }
            return Unauthorized("Неверный логин или пароль");
        } 
    }
}
