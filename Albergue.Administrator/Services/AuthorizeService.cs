using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Albergue.Administrator.Services
{
    public class AuthorizeService : IAuthorizeService
    {
        private readonly ILogger<AuthorizeService> _logger;

        public AuthorizeService(IConfiguration configuration, ILogger<AuthorizeService> logger)
        {
            _logger = logger;
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }

        public string GetToken(IdentityUser user)
        {
            try
            {
                var utcNow = DateTime.UtcNow;

                var claims = new Claim[]
                {
                        new Claim(JwtRegisteredClaimNames.Sub, user.Id),
                        new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, utcNow.ToString())
                };

                var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration.GetValue<String>("Tokens:Key")));
                var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);
                var jwt = new JwtSecurityToken(
                    signingCredentials: signingCredentials,
                    claims: claims,
                    notBefore: utcNow,
                    expires: utcNow.AddSeconds(Configuration.GetValue<int>("Tokens:Lifetime")),
                    audience: Configuration.GetValue<string>("Tokens:Audience"),
                    issuer: Configuration.GetValue<string>("Tokens:Issuer")
                    );

                return new JwtSecurityTokenHandler().WriteToken(jwt);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }
    }
}
