using SecretariaEnsino.Domain.Entidades;
using SecretariaEnsino.Infra.Contexto;
using SecretariaEnsino.Infra.Interface;

namespace SecretariaEnsino.Infra.Servico
{
    public class AlunoRepositorio : BaseRepositorio<Aluno, SecretariaEnsinoContexto>, IAlunoRepositorio
    {
        public AlunoRepositorio(SecretariaEnsinoContexto contexto) : base(contexto)
        {
        }

    }
}
