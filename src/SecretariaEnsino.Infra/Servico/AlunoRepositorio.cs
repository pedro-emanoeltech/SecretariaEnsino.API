using Microsoft.EntityFrameworkCore;
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

        public override IQueryable<Aluno> BuscarPorId(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                    throw new Exception("Id invalido");

                return _dbSet
                    .Include(a => a.Usuario!)
                    .Include(a => a.Matriculas!)
                        .ThenInclude(m => m.Turma)
                    .Where(e => e.Id == id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
