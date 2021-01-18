using Contactos.Api.Response;
using Contactos.Core.CustonEntities;
using Contactos.Core.Entities;
using Contactos.Core.Interfaces.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Contactos.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUnitOfWork work;
        private readonly IConfiguration configuration;

        public AuthController(IUnitOfWork work, IConfiguration configuration)
        {
            this.work = work;
            this.configuration = configuration;
        }

        [HttpPost]
        public async Task<IActionResult> Auth([FromBody] UserCredentials usercredentials)
        {
            var user = await this.work.AuthRepo.Login(usercredentials);

            if (user == null)
            {
                var response = new ApiResponse<string>("Not User found");
                return Ok(response);
            }
            else
            {
                var claims = new[]
                {
                    new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.Nombre+" "+user.Apellidos),
                    new Claim(ClaimTypes.Email, user.Correo),
                    new Claim(ClaimTypes.Role, user.IdRol.ToString())
                };

                var key = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(configuration.GetSection("AppSettings:Token").Value
                ));
                var Crendentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

                var tokenDescriptor = new SecurityTokenDescriptor()
                {
                    Subject = new ClaimsIdentity(claims),
                    Expires = DateTime.Now.AddDays(1),
                    SigningCredentials = Crendentials
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var WrittenToken = tokenHandler.WriteToken(token);

                var response = new ApiResponse<string>(WrittenToken);
                return Ok(response);
            }
        }
    }
}
