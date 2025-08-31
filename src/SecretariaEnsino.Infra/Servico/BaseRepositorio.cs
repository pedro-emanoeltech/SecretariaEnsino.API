using Microsoft.EntityFrameworkCore;
using SecretariaEnsino.Domain.Abastacao;
using SecretariaEnsino.Infra.Contexto;
using SecretariaEnsino.Infra.Interface;
using System.Data;
using System.Linq.Expressions;


namespace SecretariaEnsino.Infra.Servico
{
    public abstract class BaseRepositorio<TEntidade, TContexto> : IBaseRepositorio<TEntidade>
        where TEntidade : BaseEntidade, IEntidade
        where TContexto : BaseContexto
    {
        protected readonly TContexto _context;
        protected readonly DbSet<TEntidade> _dbSet;

        protected BaseRepositorio(TContexto context)
        {
            _context = context;
            _dbSet = context.Set<TEntidade>();
        }

        public virtual async Task<TEntidade> Adicionar(TEntidade entidade, bool saveChanges = true)
        {
            try
            {
                await _context.Set<TEntidade>().AddAsync(entidade);
                await _dbSet.AddAsync(entidade);
                if (saveChanges)
                {
                    await _context.SaveChangesAsync();
                }
                return entidade;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public virtual async Task<TEntidade> Atualizar(TEntidade entidade, bool saveChanges = true)
        {
            try
            {
                _dbSet.Update(entidade);
                if (saveChanges)
                {
                    await _context.SaveChangesAsync();
                }

                return entidade;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public virtual async Task<bool> Deletar(Guid id)
        {
            try
            {
                TEntidade? entidade = await BuscarPorId(id) ?? throw new NotFoundException("Registro não encontrado");
      
                _context.Set<TEntidade>().Remove(entidade);
                await _context.SaveChangesAsync();
                return true;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public virtual async Task<TEntidade?> BuscarPorId(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                    throw new Exception("Id invalido");

                return await _dbSet.FindAsync(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public virtual async Task<IQueryable<TEntidade>> BuscarTodosPorFiltro(Expression<Func<TEntidade, bool>>? filtro = null, Expression<Func<TEntidade, object>>? ordernar = null)
        {
            try
            {
                IQueryable<TEntidade> query = _dbSet;

                if (filtro != null)
                {
                    query = query.Where(filtro);
                }

                if (ordernar != null)
                {
                    query = query.OrderBy(ordernar);
                }

                return query;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public virtual async Task<IQueryable<TEntidade>> Listar()
        {
            return _dbSet;
        }
    }
}
