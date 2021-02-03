using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using IMDb.Infra.Data.Context;
using Microsoft.AspNetCore.Http;
using Application.DTOS;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;

namespace IMDb.API.Controllers
{
    public class AccountController : Controller
    {
        private readonly DB _context;
        private readonly IConfiguration _configuration;

        public AccountController(IConfiguration configuration, DB context)
        {
            _configuration = configuration;
            _context = context;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [AllowAnonymous]
        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult<UserToken>> Login([FromBody] UserDto userDto)
        {
            // var user = _userService.Authenticate(userDto.Username, userDto.Password);
            var loginDb = await _context.users
                               .Where(L => L.Email == userDto.Login.Trim() && L.Password == userDto.Password.Trim())
                               .FirstOrDefaultAsync();


            if (loginDb == null)
                return NotFound("login inválido.");

            if (loginDb != null)
            {
                return BuildToken(loginDb.Id, loginDb.Name, loginDb.Name);
            }
            else
            {
                ModelState.AddModelError(string.Empty, "login inválido.");
                return BadRequest(ModelState);
            }
        }

        [NonAction]
        private UserToken BuildToken(int Id, string Name, string UserLogin)
        {
            var claims = new[]
           {
                new Claim(JwtRegisteredClaimNames.UniqueName, Id.ToString()),
                new Claim("idUser",Id.ToString()),
                new Claim("Name",Name),
                new Claim("UserLogin",UserLogin),

                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["CtsAcs:scKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // tempo de expiração do token: 1 hora
            var expiration = DateTime.UtcNow.AddDays(7);
            JwtSecurityToken token = new JwtSecurityToken(
               issuer: null,
               audience: null,
               claims: claims,
               expires: expiration,
               signingCredentials: creds);
            return new UserToken()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = expiration
            };

        }



    }
}
