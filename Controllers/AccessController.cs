using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UsuariosApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccessController : ControllerBase
    {


        [HttpGet]
        [Authorize(Policy = "MinimumAge")]
        public IActionResult Index()
        {


            return Ok("Acesso Permitido!");
        }
    }
}
