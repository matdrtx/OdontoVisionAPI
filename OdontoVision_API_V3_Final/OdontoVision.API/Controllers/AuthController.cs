
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using OdontoVision.Application.DTOs;
using OdontoVision.Application.Services;

namespace OdontoVision.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterDto dto)
        {
            var result = _userService.Register(dto);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("login")]
        public IActionResult Login(LoginDto dto)
        {
            var result = _userService.Login(dto);
            return result.Success ? Ok(result) : Unauthorized(result);
        }

        [Authorize]
        [HttpGet("me")]
        public IActionResult Me()
        {
            return Ok(new { Email = User.Identity?.Name, Role = User.FindFirst("role")?.Value });
        }
    }
}
