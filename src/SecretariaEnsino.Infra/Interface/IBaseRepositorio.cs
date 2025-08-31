using SecretariaEnsino.Domain.Abastacao;
using System.Linq.Expressions;


namespace SecretariaEnsino.Infra.Interface
{
    public interface IBaseRepositorio<TEntidade> where TEntidade : BaseEntidade, IEntidade
    {
        Task<TEntidade> AdicionarAsync(TEntidade entidade, bool saveChanges = true);

        Task<TEntidade> AtualizarAsync(TEntidade entidade, bool saveChanges = true);

        Task<bool> DeletarAsync(Guid id);

        Task<TEntidade?> BuscarPorIdAsync(Guid id);
 
        Task<IQueryable<TEntidade>> BuscarTodosPorFiltroAsync(Expression<Func<TEntidade, bool>>? filtro = null, Expression<Func<TEntidade, object>>? ordernar = null);
 
    }
}
