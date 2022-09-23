using Domain.Entities.AppUSerModels;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Service.Helpers.Token
{
    public class Token : IToken
    {
        private readonly IConfiguration _configuration;
        public Token(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string CreateToken(AppUser user, List<string> roles)
        {
            var claims = new List<Claim>
            {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id),
            new Claim(JwtRegisteredClaimNames.Sub, user.Email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(ClaimTypes.NameIdentifier,user.Id )
            };
            
            roles.ForEach(role =>
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            });

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.UtcNow.AddDays(1);

            var token = new JwtSecurityToken(
                _configuration["Jwt:Audience"],
                _configuration["Jwt:Issuer"],
                claims,
                expires: expires,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }

}
