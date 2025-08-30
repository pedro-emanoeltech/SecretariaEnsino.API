using SecretariaEnsino.Domain.Abastacao;

namespace SecretariaEnsino.App.Filtro
{
    public interface IBaseFiltro<TEntidade> where TEntidade : IEntidade
    {
        public Task<IQueryable<TEntidade>> BuildAsync(IQueryable<TEntidade> filtro);
    }

}
