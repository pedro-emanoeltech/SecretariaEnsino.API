using Microsoft.EntityFrameworkCore.Query;
using SecretariaEnsino.Domain.Abastacao;
using System.Linq.Expressions;


namespace SecretariaEnsino.Infra.Interface
{
    public interface IBaseRepositorio<TEntity> where TEntity : BaseEntidade, IEntidade
    {
        Task<TEntity> Adicionar(TEntity entity, bool saveChanges = true);

        Task<TEntity> Atualizar(TEntity entity, bool saveChanges = true);

        Task<bool> Deletar(Guid id);

        Task<TEntity?> BuscarPorId(Guid id);

        Task<TEntity?> BuscarPorFiltro(Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null);

        Task<IEnumerable<TEntity>?> BuscarTodosPorFiltro(Expression<Func<TEntity, bool>>? predicate = null, Expression<Func<TEntity, object>>? orderBy = null);

        Task<IQueryable<TEntity>?> ObterDataSet();
    }
}
