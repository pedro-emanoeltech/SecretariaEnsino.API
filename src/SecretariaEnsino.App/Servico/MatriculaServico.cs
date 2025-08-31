using AutoMapper;
using FluentValidation;
using SecretariaEnsino.App.DTO.DtoRequisicao;
using SecretariaEnsino.App.DTO.DtoRespostas;
using SecretariaEnsino.App.Interface;
using SecretariaEnsino.Domain.Entidades;
using SecretariaEnsino.Infra.Interface;

namespace SecretariaEnsino.App.Servico
{
    public class MatriculaServico : BaseServico<Matricula, MatriculaRequisicao, MatriculaResposta>, IMatriculaServico
    {
        public MatriculaServico(
            IMapper mapper,
            IMatriculaRepositorio repositorio,
            IValidator<MatriculaRequisicao> validator)
            : base(repositorio, mapper, validator)
        {
 
        }

    }
}
