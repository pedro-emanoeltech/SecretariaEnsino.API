using SecretariaEnsino.App.Filtro;
using SecretariaEnsino.Domain.Abastacao;
using System.Linq.Expressions;

namespace SecretariaEnsino.App.Interface
{
    public interface IBaseService<TEntidade, TDtoRequisicao, TDtoResposta>
        where TEntidade : BaseEntidade, IEntidade
        where TDtoRequisicao : IBaseDto
    {
        Task<TDtoResposta> AdicionarAsync(TDtoRequisicao dtoRequisicao);
        Task<TDtoResposta> AtualizarAsync(Guid id, TDtoRequisicao dtoRequisicao);
        Task<TDtoResposta> BuscarPorIdAsync(Guid id);
        Task<bool> Deletar(Guid id);
        Task<IEnumerable<TDtoResposta>> BuscarTodosAsync();
        Task<IQueryable<TDtoResposta>> BuscarPorFiltroAsync<TBuilderFiltro>(IBaseFiltro<TEntidade> builderFiltro = null)
             where TBuilderFiltro : class, IBaseFiltro<TEntidade>;

    }
}
