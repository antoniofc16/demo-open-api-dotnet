using DemoOpenAPI.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoOpenAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        ///<summary>
        /// Genera un token de autenticación.
        ///</summary>
        ///<response code="200">Operación exitosa</response>
        ///<response code="500">Error interno del servidor</response>
        [HttpGet("token")]
        public IActionResult Login()
        {
            var jwtService = new JWTTokenService();
            string token = jwtService.GetJwtSecurityToken("Pedro Perez", "pedro.perez@nttdata.com", "pedroperez01");
            return Ok(token);
        }
    }
}
