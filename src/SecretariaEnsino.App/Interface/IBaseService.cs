using SecretariaEnsino.App.Filtro;
using SecretariaEnsino.Domain.Abastacao;
using System.Linq.Expressions;

namespace SecretariaEnsino.App.Interface
{
    public interface IBaseService<TEntidade, TDtoRequisicao, TDtoResposta>
        where TEntidade : BaseEntidade, IEntidade
        where TDtoRequisicao : IBaseDto
    {
        Task<TDtoResposta> Adicionar(TDtoRequisicao dtoRequisicao);
        Task<TDtoResposta> Atualizar(Guid id, TDtoRequisicao dtoRequisicao);
        Task<TDtoResposta> BuscarPorId(Guid id);
        Task<bool> Deletar(Guid id);
        Task<IEnumerable<TDtoResposta>> BuscarTodos();
        Task<IQueryable<TDtoResposta>> BuscarPorFiltro<TBuilderFiltro>(IBaseFiltro<TEntidade> builderFiltro = null)
             where TBuilderFiltro : class, IBaseFiltro<TEntidade>;

    }
}
