using AutoMapper;
using FluentValidation;
using SecretariaEnsino.App.Filtro;
using SecretariaEnsino.App.Interface;
using SecretariaEnsino.Domain.Abastacao;
using SecretariaEnsino.Infra.Interface;

namespace SecretariaEnsino.App.Servico
{
    public abstract class BaseServico<TEntidade, TDtoRequisicao, TDtoResposta> : IBaseService<TEntidade, TDtoRequisicao, TDtoResposta>
        where TEntidade : BaseEntidade, IEntidade
        where TDtoRequisicao : IBaseDto
        where TDtoResposta : IBaseDto
    {

        private readonly IMapper _mapper;
        private readonly IBaseRepositorio<TEntidade> _repositorio;
        private readonly IValidator<TDtoRequisicao> _validator;

        protected BaseServico(IBaseRepositorio<TEntidade> repositorio, IMapper mapper, IValidator<TDtoRequisicao> validator)
        {
            _repositorio = repositorio;
            _mapper = mapper;
            _validator = validator;
        }

        /// <summary>
        /// metodo call antes de Adicionar aplicar validação ou modificação na entidade.
        /// </summary>
        /// <param name="entidade"></param>
        protected virtual async Task AntesDeAdicionarAsync(TEntidade entidade) => await Task.CompletedTask;

        /// <summary>
        /// metodo call antes de Atualizar aplicar validação ou modificação na entidade.
        /// </summary>
        /// <param name="entidade"></param>
        protected virtual async Task AntesDeAtualizarAsync(Guid id, TEntidade entidade) => await Task.CompletedTask;

        public virtual async Task<TDtoResposta> AdicionarAsync(TDtoRequisicao dtoRequisicao)
        {
            var resultadoValidacao = await _validator.ValidateAsync(dtoRequisicao);
            if (!resultadoValidacao.IsValid)
                throw new ValidationException(string.Join("; ", resultadoValidacao.Errors.Select(e => e.ErrorMessage)));

            var entidade = _mapper.Map<TEntidade>(dtoRequisicao);

            await AntesDeAdicionarAsync(entidade);
            await _repositorio.AdicionarAsync(entidade);

            return _mapper.Map<TDtoResposta>(entidade);
        }

        public virtual async Task<TDtoResposta> AtualizarAsync(Guid id, TDtoRequisicao dtoRequisicao)
        {
            var resultadoValidacao = await _validator.ValidateAsync(dtoRequisicao);
            if (!resultadoValidacao.IsValid)
                throw new ValidationException(string.Join("; ", resultadoValidacao.Errors.Select(e => e.ErrorMessage)));

            var entidade = await _repositorio.BuscarPorIdAsync(id) ?? throw new NotFoundException("Registro não encontrado");

            _mapper.Map(dtoRequisicao, entidade);

            await AntesDeAtualizarAsync(id, entidade);
            await _repositorio.AtualizarAsync(entidade);

            return _mapper.Map<TDtoResposta>(entidade);
        }

        public virtual async Task<TDtoResposta> BuscarPorIdAsync(Guid id)
        {
            var entidade = await _repositorio.BuscarPorIdAsync(id) ?? throw new NotFoundException("Registro não encontrado");
            return _mapper.Map<TDtoResposta>(entidade);
        }

        public virtual async Task<bool> Deletar(Guid id)
        {
            await _repositorio.DeletarAsync(id);
            return true;
        }

        public virtual async Task<IEnumerable<TDtoResposta>> BuscarTodosAsync()
        {
            var registros = await _repositorio.BuscarTodosPorFiltroAsync();
            return _mapper.ProjectTo<TDtoResposta>(registros);
        }

        public virtual async Task<IQueryable<TDtoResposta>> BuscarPorFiltroAsync<TBuilderFiltro>(IBaseFiltro<TEntidade> builderFiltro = null)
         where TBuilderFiltro : class, IBaseFiltro<TEntidade>
        {
            var query = await _repositorio.BuscarTodosPorFiltroAsync();

            if (builderFiltro != null)
            {
                query = await builderFiltro.BuildAsync(query);
            }

            return _mapper.ProjectTo<TDtoResposta>(query);
        }
    }

}

