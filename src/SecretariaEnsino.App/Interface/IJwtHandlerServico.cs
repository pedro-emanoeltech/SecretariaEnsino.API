using SecretariaEnsino.App.DTO.DtoModelo;
using SecretariaEnsino.Domain.Entidades;
using System.Security.Claims;

namespace SecretariaEnsino.App.Interface
{
    public interface IJwtHandlerServico
    {
        Task<TokenAcesso> GerarTokenAcessoAsync(Usuario usuario);
        ClaimsPrincipal ValidateJwtToken(string token);

    }
}
