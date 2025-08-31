using Microsoft.EntityFrameworkCore;
using SecretariaEnsino.Domain.Entidades;
using SecretariaEnsino.Infra.Contexto;
using SecretariaEnsino.Infra.Interface;

namespace SecretariaEnsino.Infra.Servico
{
    public class UsuarioRepositorio : BaseRepositorio<Usuario, SecretariaEnsinoContexto>, IUsuarioRepositorio
    {
        public UsuarioRepositorio(SecretariaEnsinoContexto contexto) : base(contexto)
        {
        }

        public async Task<Usuario?> ObterUsuarioPorEmailAsync(string email)
        {
            return await _dbSet.FirstOrDefaultAsync(predicate: x => x.Email.ToLower() == email.ToLower());
        }
    }
}
