using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
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

        public virtual async Task<TDtoResposta> Adicionar(TDtoRequisicao dtoRequisicao)
        {
            var resultadoValidacao = await _validator.ValidateAsync(dtoRequisicao);
            if (!resultadoValidacao.IsValid)
                throw new ValidationException(string.Join("; ", resultadoValidacao.Errors.Select(e => e.ErrorMessage)));

            var entidade = _mapper.Map<TEntidade>(dtoRequisicao);
            await _repositorio.Adicionar(entidade);

            return _mapper.Map<TDtoResposta>(entidade);
        }

        public virtual async Task<TDtoResposta> Atualizar(Guid id, TDtoRequisicao dtoRequisicao)
        {
            var resultadoValidacao = await _validator.ValidateAsync(dtoRequisicao);
            if (!resultadoValidacao.IsValid)
                throw new ValidationException(string.Join("; ", resultadoValidacao.Errors.Select(e => e.ErrorMessage)));

            var entidade = await _repositorio.BuscarPorId(id) ?? throw new NotFoundException("Registro não encontrado");

            _mapper.Map(dtoRequisicao, entidade);
            await _repositorio.Atualizar(entidade);

            return _mapper.Map<TDtoResposta>(entidade);
        }

        public virtual async Task<TDtoResposta> BuscarPorId(Guid id)
        {
            var entidade = await _repositorio.BuscarPorId(id) ?? throw new NotFoundException("Registro não encontrado");
            return _mapper.Map<TDtoResposta>(entidade);
        }

        public virtual async Task<bool> Deletar(Guid id)
        {
            await _repositorio.Deletar(id);
            return true;
        }

        public virtual async Task<IEnumerable<TDtoResposta>> BuscarTodos()
        {
            var registros = await _repositorio.BuscarTodosPorFiltro();
            return _mapper.ProjectTo<TDtoResposta>(registros);
        }

        public virtual async Task<IQueryable<TDtoResposta>> BuscarPorFiltro<TBuilderFiltro>(IBaseFiltro<TEntidade> builderFiltro = null)
         where TBuilderFiltro : class, IBaseFiltro<TEntidade>
        {
            var query = await _repositorio.BuscarTodosPorFiltro();

            if (builderFiltro != null)
            {
                query = await builderFiltro.BuildAsync(query);
            }

            return _mapper.ProjectTo<TDtoResposta>(query);
        }
    }

}

