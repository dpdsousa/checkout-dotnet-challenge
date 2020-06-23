using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using CheckoutChallenge.PaymentGateway.WebApi.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace CheckoutChallenge.PaymentGateway.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IOptions<AppSettings> _appSettings;

        public AuthenticationController(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings;
        }

        [HttpPost]
        public IActionResult Token()
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.Value.Secret));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                    _appSettings.Value.Issuer,
                    expires: DateTime.UtcNow.AddSeconds(600),
                    signingCredentials: signingCredentials);

            return Ok(new
            {
                AccessToken = new JwtSecurityTokenHandler().WriteToken(token)
            });
        }
    }
}
