using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ToDoAppWebService.Models;
using Task = Core.Entities.Task;

namespace ToDoAppWebService.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AuthenticationController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<User> _userManager;

        public AuthenticationController(IConfiguration configuration, UserManager<User> userManager)
        {
            _configuration = configuration;
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody]RegisterModel model)
        {
            var userExists = await _userManager.FindByNameAsync(model.Username);
            if (userExists != null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            var user = new User()
            {
                UserName = model.Username,
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString()
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return Ok();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([FromBody]LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(model.Username);
                if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
                {
                    var authClaims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.UserName),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                    };

                    var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

                    var token = new JwtSecurityToken(
                        issuer: _configuration["JWT:ValidIssuer"],  
                        audience: _configuration["JWT:ValidAudience"],
                        expires: DateTime.Now.AddHours(3),
                        claims: authClaims,
                        signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                    );

                    return Ok(new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(token),
                        expiration = token.ValidTo
                    });
                }

                return Unauthorized();
            }

            return BadRequest();
        }
    }
}