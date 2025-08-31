using SecretariaEnsino.App.DTO.DtoRequisicao;
using SecretariaEnsino.Domain.Entidades;

namespace SecretariaEnsino.App.Filtro
{
    public class TurmaFiltroBuilder : BaseFiltro<Turma>
    {
        private readonly TurmaDtoFiltro _filter;

        public TurmaFiltroBuilder(TurmaDtoFiltro filter)
        {
            _filter = filter;
        }

        private void AplicarFiltros()
        {
            if (_filter == null) return;

            if (!string.IsNullOrEmpty(_filter.Nome))
                _query = _query.Where(t => t.Nome.Contains(_filter.Nome));

            if (!string.IsNullOrEmpty(_filter.Descricao))
                _query = _query.Where(t => t.Descricao.Contains(_filter.Descricao));

            if (!string.IsNullOrEmpty(_filter.Professor))
                _query = _query.Where(t => t.Professor.Contains(_filter.Professor));

            if (_filter.Status.HasValue)
                _query = _query.Where(t => t.Status == _filter.Status.Value);
        }

        public override async Task<IQueryable<Turma>> BuildAsync(IQueryable<Turma> queryable)
        {
            _query = queryable;
            _query = _query.OrderBy(x => x.Nome);
            AplicarFiltros();
            return await Task.FromResult(_query);
        }
    }


}
