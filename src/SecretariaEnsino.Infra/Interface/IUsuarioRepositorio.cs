using SecretariaEnsino.Domain.Entidades;

namespace SecretariaEnsino.Infra.Interface
{
    public interface IUsuarioRepositorio : IBaseRepositorio<Usuario>
    {
        Task<Usuario?> ObterUsuarioPorEmailAsync(string email);
    }
}
