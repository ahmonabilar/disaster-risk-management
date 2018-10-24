using Drm.Data.Entities;
using Drm.WebApi.Models;
using Microsoft.AspNetCore.Identity;
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

namespace Drm.WebApi.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<DrmUser> _signInManager;
        private readonly UserManager<DrmUser> _userManager;
        private readonly IConfiguration _config;

        public AccountController(
            SignInManager<DrmUser> signInManager, 
            UserManager<DrmUser> userManager,
            IConfiguration config)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _config = config;
        }

        [HttpPost]
        public async Task<IActionResult> CreateToken([FromBody] LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(model.Username);

                if(user != null)
                {
                    var result = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);

                    if(result.Succeeded)
                    {
                        var claims = new[]
                        {
                            new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                            new Claim("role", "Admin"),
                            new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName)
                        };

                        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:Key"]));
                        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                        var token = new JwtSecurityToken(
                            _config["Tokens:Issuer"],
                            _config["Tokens:Audience"],
                            claims,
                            expires: DateTime.UtcNow.AddMinutes(Convert.ToInt32(_config["Tokens:ExpirationInMinutes"])),
                            signingCredentials: creds);

                        var results = new
                        {
                            token = new JwtSecurityTokenHandler().WriteToken(token),
                            expiration = token.ValidTo
                        };

                        return Created("", results);
                    }
                }
            }

            return BadRequest();
        }
    }
}
