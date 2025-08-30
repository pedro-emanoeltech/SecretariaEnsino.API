using System.Security.Claims;

namespace SecretariaEnsino.App.Interface
{
    public interface IJwtHandler
    {
        Task<string> GerarTokenAcessoAsync();
        ClaimsPrincipal ValidateJwtToken(string token);

    }
}
