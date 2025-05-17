using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using WebApp.Api.Services;

namespace WebApp.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly UserService _userService;

    public AuthController(UserService userService)
    {
        _userService = userService;
    }

    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request)
    {
        var success = _userService.Register(request.Email, request.Password);
        if (!success)
            return BadRequest("User already exists");

        return Ok("User registered");
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
        var success = _userService.Login(request.Email, request.Password);
        if (!success)
            return Unauthorized();

        return Ok("Login successful");
    }
}
