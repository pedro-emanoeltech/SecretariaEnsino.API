using SecretariaEnsino.Domain.Abastacao;

namespace SecretariaEnsino.App.Filtro
{
    public abstract class BaseFiltro<TEntidade> : IBaseFiltro<TEntidade> where TEntidade : IEntidade
    {
        public IQueryable<TEntidade> _query;

        public BaseFiltro()
        {
            _query = Enumerable.Empty<TEntidade>().AsQueryable();
        }

        public abstract Task<IQueryable<TEntidade>> BuildAsync(IQueryable<TEntidade> filtro);
    }

}
