using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UsuariosApi.Data;
using UsuariosApi.Data.Dtos;
using UsuariosApi.Models;
using UsuariosApi.Services;

namespace UsuariosApi.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly UserService _userService;

    public UserController(UserService userService)
    {
        _userService = userService;
    }


    [HttpPost("register")]
    public async Task<IActionResult> RegisterUser(RegisterUserDto registerUserDto)
    {
        IdentityResult result = await _userService.RegisterAsync(registerUserDto);

        if (!result.Succeeded)
            return BadRequest(result.Errors);

        return Ok("User registered");
    }

    [HttpPost("login")]
    public async Task<IActionResult> LoginAsync(LoginUserDto loginUserDto)
    {
        Microsoft.AspNetCore.Identity.SignInResult result = await _userService.LoginAsync(loginUserDto);

        if (!result.Succeeded)
            return BadRequest("Falha ao Autenticar");

        return Ok("User Logged");
    }

}
