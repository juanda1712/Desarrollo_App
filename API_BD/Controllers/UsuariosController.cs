using API_BD.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API_BD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {


        public readonly WEB_APIContext _dbcontex;
        public IConfiguration _Configuration;


        public UsuariosController(WEB_APIContext _contex , IConfiguration _config)
        {
            _dbcontex = _contex;
            _Configuration = _config;
        }

        [HttpPost]
        [Route("Session")]
        public IActionResult Session([FromBody] Usuario objeto)
        {
            try
            {

                Usuario objUsr = _dbcontex.Usuarios.Where(u => u.Nombre == objeto.Nombre && u.Contraseña == objeto.Contraseña).FirstOrDefault(); 
                if (objUsr == null)
                {
                    return NotFound("Credenciales Invalidas");
                }

                var jwt = _Configuration.GetSection("Jwt").Get<Jwt>();
                var Claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub , jwt.Subject),
                    new Claim(JwtRegisteredClaimNames.Jti , Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat , DateTime.UtcNow.ToString()),
                    new Claim("Nombre", objeto.Nombre),
                    new Claim("Id" , objUsr.Idusuario.ToString()),
                    new Claim("Perfil", objUsr.Perfil)
                };


                SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.Key));
                SigningCredentials singCred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                JwtSecurityToken jwtoken = new JwtSecurityToken(
                    jwt.Issuer,
                    jwt.Audience,
                    Claims,
                    expires: DateTime.Now.AddMinutes(5),
                    signingCredentials: singCred
                    );

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "OK" , token = new JwtSecurityTokenHandler().WriteToken(jwtoken) });
            }
            
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status406NotAcceptable, new { mensaje = ex.Message });
            }

        }




    }
}
