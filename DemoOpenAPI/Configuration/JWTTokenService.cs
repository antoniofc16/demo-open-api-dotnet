using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DemoOpenAPI.Configuration
{
    public class JWTTokenService()
    {
        public string GetJwtSecurityToken(string fullName, string email, string username)
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            string issuer = config.GetValue<string>("Jwt:Issuer")!;
            string audience = config.GetValue<string>("Jwt:Audience")!;
            // Definimos una llave aleatoria para poder generar el token, esta llave debe ser secreta y no debe compartirse
            string secretKey = config.GetValue<string>("Jwt:Key")!;
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
                {
                    new Claim("UserName", username, ClaimValueTypes.String),
                    new Claim("Name", fullName, ClaimValueTypes.String),
                    new Claim("Email", email, ClaimValueTypes.String),
                };

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(240),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
