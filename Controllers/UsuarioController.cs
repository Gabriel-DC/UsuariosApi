using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UsuariosApi.Data.Dtos;

namespace UsuariosApi.Controllers;

[ApiController]
[Route("[controller]")]
public class UsuarioController : ControllerBase
{
    private readonly IMapper _mapper;

    public UsuarioController(IMapper mapper)
    {
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult RegisSterUser(RegisterUserDto registerUserDto)
    {


        throw new NotImplementedException();
    }

}
