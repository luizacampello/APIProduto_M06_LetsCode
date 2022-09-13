using ApiClientes.Core.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ApiClientes.Core.Services
{
    public class TokenService : ITokenService
    {
        public IConfiguration _configuration;
        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GenerateTokenProdutos(string nome, string permissao)
        {
            //Chave secreta para validação do Token
            var key = Encoding.ASCII.GetBytes(_configuration.GetValue<string>("secretKey"));

            //Corpo do JWT
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = "APIClientes.com",
                Audience = "APIProdutos.com",
                Expires = DateTime.UtcNow.AddMinutes(15),
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, nome),
                    new Claim(ClaimTypes.Role, permissao),
                    new Claim("teste", "123")
                }),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
