using SecretariaEnsino.App.DTO.DtoRequisicao;
using SecretariaEnsino.Domain.Entidades;

namespace SecretariaEnsino.App.Filtro
{
    public class AlunoBuilder : BaseFiltro<Aluno>
    {
        private readonly AlunoDtoFiltro _filter;

        public AlunoBuilder(AlunoDtoFiltro filter)
        {
            _filter = filter;
        }

        private void AplicarFiltros()
        {
            if (_filter == null) return;

            if (!string.IsNullOrEmpty(_filter.Nome))
                _query = _query.Where(a => a.Nome.Contains(_filter.Nome));

        }

        public override async Task<IQueryable<Aluno>> BuildAsync(IQueryable<Aluno> queryable)
        {
            _query = queryable;
            AplicarFiltros();
            return await Task.FromResult(_query);
        }
    }

}
