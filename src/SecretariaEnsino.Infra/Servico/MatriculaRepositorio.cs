using SecretariaEnsino.Domain.Entidades;
using SecretariaEnsino.Infra.Contexto;
using SecretariaEnsino.Infra.Interface;

namespace SecretariaEnsino.Infra.Servico
{
    public class MatriculaRepositorio : BaseRepositorio<Matricula, SecretariaEnsinoContexto>, IMatriculaRepositorio
    {
        public MatriculaRepositorio(SecretariaEnsinoContexto contexto) : base(contexto)
        {
        }

    }
}
