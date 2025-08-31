using SecretariaEnsino.App.DTO.DtoRequisicao;
using SecretariaEnsino.Domain.Entidades;

namespace SecretariaEnsino.App.Filtro
{
    public class AlunoFiltroBuilder : BaseFiltro<Aluno>
    {
        private readonly AlunoDtoFiltro _filter;

        public AlunoFiltroBuilder(AlunoDtoFiltro filter)
        {
            _filter = filter;
        }

        private void AplicarFiltros()
        {
            if (_filter == null) return;

            if (!string.IsNullOrEmpty(_filter.Nome))
                _query = _query.Where(a => a.Usuario.Nome.Contains(_filter.Nome));

            if (!string.IsNullOrEmpty(_filter.Cpf))
                _query = _query.Where(a => a.Cpf == _filter.Cpf);

            if (!string.IsNullOrEmpty(_filter.Email))
                _query = _query.Where(a => a.Usuario.Email == _filter.Email);

            if (_filter.Ativo.HasValue)
                _query = _query.Where(a => a.Usuario.Ativo == _filter.Ativo.Value);
        }

        public override async Task<IQueryable<Aluno>> BuildAsync(IQueryable<Aluno> queryable)
        {
            _query = queryable;
            _query = _query.OrderBy(x => x.Usuario.Nome);
            AplicarFiltros();
            return await Task.FromResult(_query);
        }
    }


}
