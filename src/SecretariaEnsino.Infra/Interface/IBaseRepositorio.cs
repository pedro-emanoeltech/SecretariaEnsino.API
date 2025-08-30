using SecretariaEnsino.Domain.Abastacao;
using System.Linq.Expressions;


namespace SecretariaEnsino.Infra.Interface
{
    public interface IBaseRepositorio<TEntidade> where TEntidade : BaseEntidade, IEntidade
    {
        Task<TEntidade> Adicionar(TEntidade entidade, bool saveChanges = true);

        Task<TEntidade> Atualizar(TEntidade entidade, bool saveChanges = true);

        Task<bool> Deletar(Guid id);

        Task<TEntidade?> BuscarPorId(Guid id);
 
        Task<IQueryable<TEntidade>> BuscarTodosPorFiltro(Expression<Func<TEntidade, bool>>? filtro = null, Expression<Func<TEntidade, object>>? ordernar = null);
 
    }
}
