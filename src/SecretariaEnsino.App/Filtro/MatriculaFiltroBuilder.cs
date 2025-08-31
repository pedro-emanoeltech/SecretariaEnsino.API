using SecretariaEnsino.App.DTO.DtoRequisicao;
using SecretariaEnsino.Domain.Entidades;

namespace SecretariaEnsino.App.Filtro
{
    public class MatriculaFiltroBuilder : BaseFiltro<Matricula>
    {
        private readonly MatriculaDtoFiltro _filter;

        public MatriculaFiltroBuilder(MatriculaDtoFiltro filter)
        {
            _filter = filter;
        }

        private void AplicarFiltros()
        {
            if (_filter == null) return;

            if (_filter.AlunoId.HasValue)
                _query = _query.Where(m => m.AlunoId == _filter.AlunoId.Value);

            if (_filter.TurmaId.HasValue)
                _query = _query.Where(m => m.TurmaId == _filter.TurmaId.Value);

            if (!string.IsNullOrEmpty(_filter.NomeAluno))
                _query = _query.Where(m => m.Aluno.Usuario.Nome.Contains(_filter.NomeAluno));

            if (!string.IsNullOrEmpty(_filter.CpfAluno))
                _query = _query.Where(m => m.Aluno.Cpf == _filter.CpfAluno);

            if (!string.IsNullOrEmpty(_filter.EmailAluno))
                _query = _query.Where(m => m.Aluno.Usuario.Email == _filter.EmailAluno);

            if (!string.IsNullOrEmpty(_filter.NomeTurma))
                _query = _query.Where(m => m.Turma.Nome.Contains(_filter.NomeTurma));

            if (_filter.Status.HasValue)
                _query = _query.Where(m => m.Status == _filter.Status.Value);

            if (_filter.CertificadoEmitido.HasValue)
                _query = _query.Where(m => m.CertificadoEmitido == _filter.CertificadoEmitido.Value);
        }

        public override async Task<IQueryable<Matricula>> BuildAsync(IQueryable<Matricula> queryable)
        {
            _query = queryable;
            _query = _query.OrderBy(x => x.DataMatricula);
            AplicarFiltros();
            return await Task.FromResult(_query);
        }
    }
}
