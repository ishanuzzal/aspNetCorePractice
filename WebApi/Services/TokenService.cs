using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using WebApi.Interfaces;
using WebApi.Models;
namespace WebApi.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _config;
        private readonly SymmetricSecurityKey _key;
        public TokenService(IConfiguration config) { 
            _config = config;
            _key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_config["JWT:Signingkey"]));
        }
        public string CreateToken(AppUser appuser)
        {
            var claim = new List<Claim>
            {
                //new Claim(JwtRegisteredClaimNames.Email, appuser.Email),
                new Claim(JwtRegisteredClaimNames.GivenName,appuser.UserName)
            };

            var creeds = new SigningCredentials(_key,SecurityAlgorithms.HmacSha512Signature);
            var tokenDescriptior = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claim),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creeds,
                Issuer = _config["jwt:Issuer"],
                Audience = _config["jwt:Audience"]
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptior);

            return tokenHandler.WriteToken(token);

        }
    }
}
