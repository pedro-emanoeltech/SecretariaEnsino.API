using Microsoft.IdentityModel.Tokens;
using SecretariaEnsino.App.Interface;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SecretariaEnsino.App.Servico
{
    public class JwtHandler : IJwtHandler
    {
        public JwtHandler()
        {
                
        }

        public async Task<string> GerarTokenAcessoAsync()
        {
            var dataExpiracao = DateTime.UtcNow.AddHours(8);
            var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Environment.GetEnvironmentVariable("SecretKey")!));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var listClaim = new List<Claim>();

            var securityToken = new JwtSecurityToken(
                null,
                null,
                listClaim,
                null,
                dataExpiracao,
                credentials);

            return new JwtSecurityTokenHandler().WriteToken(securityToken);
        }

        public ClaimsPrincipal ValidateJwtToken(string token)
        {
            var securityKey = Encoding.ASCII.GetBytes(Environment.GetEnvironmentVariable("SecretKey")!);

            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var claimsPrincipal = tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Environment.GetEnvironmentVariable("Issuer"),
                    ValidAudience = Environment.GetEnvironmentVariable("Audience"),
                    IssuerSigningKey = new SymmetricSecurityKey(securityKey)
                }, out SecurityToken validatedToken);

                return claimsPrincipal;
            }
            catch (SecurityTokenExpiredException)
            {
                throw new ApplicationException("Token de acesso Expirou.");
            }
        }

    }
}
