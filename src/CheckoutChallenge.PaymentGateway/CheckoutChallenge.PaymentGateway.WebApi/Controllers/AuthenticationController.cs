using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using CheckoutChallenge.PaymentGateway.WebApi.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace CheckoutChallenge.PaymentGateway.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly AppSettings _appSettings;

        public AuthenticationController(AppSettings appSettings)
        {
            _appSettings = appSettings;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Token()
        {
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);

            var token = new JwtSecurityToken(
                 expires: DateTime.UtcNow.AddSeconds(360),
                 signingCredentials: new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature));

            return Ok(new
            {
                AccessToken = new JwtSecurityTokenHandler().WriteToken(token),
            });
        }
    }
}
