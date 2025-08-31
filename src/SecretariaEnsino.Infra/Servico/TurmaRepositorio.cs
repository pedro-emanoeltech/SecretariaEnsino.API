using SecretariaEnsino.Domain.Entidades;
using SecretariaEnsino.Infra.Contexto;
using SecretariaEnsino.Infra.Interface;

namespace SecretariaEnsino.Infra.Servico
{
    public class TurmaRepositorio : BaseRepositorio<Turma, SecretariaEnsinoContexto>, ITurmaRepositorio
    {
        public TurmaRepositorio(SecretariaEnsinoContexto contexto) : base(contexto)
        {
        }

    }
}
