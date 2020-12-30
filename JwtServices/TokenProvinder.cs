using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace JwtServices
{
    public class TokenProvinder
    {
        private readonly string _secret;
        private readonly string _expiracao;

        public TokenProvinder(IConfiguration config)
        {
            _secret = config.GetSection("JwtConfig").GetSection("secret").Value;
            _expiracao = config.GetSection("JwtConfig").GetSection("expirationInMinutes").Value;
        }

        public string GenerateToken(string username)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_secret);

            var tokenDecryptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, username),
                }),
                
                //Expires = DateTime.Now.AddMinutes(double.Parse(_expiracao)),
                Expires = DateTime.UtcNow.AddMinutes(double.Parse(_expiracao)),

                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            };

            var token = tokenHandler.CreateToken(tokenDecryptor);

            return tokenHandler.WriteToken(token);



        }
    }
}
