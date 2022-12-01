using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

using Microsoft.IdentityModel.Tokens;

using ToDoApp.Application.Interfaces;

namespace ToDoApp.Identity.JwtToken
{
    public class JwtTokenService : ITokenService
    {
        private readonly ISettings _settings;

        public JwtTokenService(ISettings settings)
        {
            _settings = settings;
        }

        public string GenerateToken(string username)
        {
            var symmetricKey = Convert.FromBase64String(_settings.TokenKey);
            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                            {
                                new Claim(ClaimTypes.Name, username)
                            }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(symmetricKey), SecurityAlgorithms.HmacSha256Signature)
            };

            var stoken = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(stoken);

            return token;
        }
    }
}
