using BackendCrudUser.Models;
using BackendCrudUser.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BackendCrudUser.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly AplicationDbContext _context;
        private readonly IConfiguration config;
        public LoginController(AplicationDbContext context, IConfiguration _config)
        {
            _context = context;
            config = _config;
        }

        [HttpPost]
        public async Task<IActionResult> Post(LoginUsuario Login)
        {
            try
            {
                Usuarios usuario = await _context.Usuarios.Where(x => x.Usuario == Login.Usuario).FirstOrDefaultAsync();

                if (usuario == null)
                {
                    return NotFound();
                }

                if(usuario.Usuario == Login.Usuario && usuario.Pass == Login.Pass){
                    var secretKey = config.GetValue<string>("SecretKey");
                    var key = Encoding.ASCII.GetBytes(secretKey);

                    var claims = new ClaimsIdentity();
                    claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, Login.Usuario));

                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = claims,
                        Expires = DateTime.UtcNow.AddHours(4),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)

                    };

                    var tokenHandler = new JwtSecurityTokenHandler();
                    var createdToken = tokenHandler.CreateToken(tokenDescriptor);

                    string bearer_token = tokenHandler.WriteToken(createdToken);
                    return Ok(new { token = bearer_token });

                }
                else
                {
                    return Forbid();
                }

               


            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
