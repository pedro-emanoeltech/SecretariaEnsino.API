using AutoMapper;
using FluentValidation;
using SecretariaEnsino.App.DTO.DtoRequisicao;
using SecretariaEnsino.App.DTO.DtoRespostas;
using SecretariaEnsino.App.Interface;
using SecretariaEnsino.Domain.Entidades;
using SecretariaEnsino.Infra.Interface;

namespace SecretariaEnsino.App.Servico
{
    public class TurmaServico : BaseServico<Turma, TurmaRequisicao, TurmaResposta>, ITurmaServico
    {
        public TurmaServico(
            IMapper mapper,
            ITurmaRepositorio repositorio,
            IValidator<TurmaRequisicao> validator)
            : base(repositorio, mapper, validator)
        {
 
        }

    }
}
