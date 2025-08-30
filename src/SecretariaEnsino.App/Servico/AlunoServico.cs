using AutoMapper;
using FluentValidation;
using SecretariaEnsino.App.DTO.DtoRequisicao;
using SecretariaEnsino.App.DTO.DtoRespostas;
using SecretariaEnsino.App.Interface;
using SecretariaEnsino.Domain.Entidades;
using SecretariaEnsino.Infra.Interface;

namespace SecretariaEnsino.App.Servico
{
    public class AlunoServico : BaseService<Aluno, AlunoRequisicao, AlunoResposta>, IAlunoServico
    {
        public AlunoServico(
            IMapper mapper,
            IAlunoRepositorio repositorio,
            IValidator<AlunoRequisicao> validator)
            : base(repositorio, mapper, validator)
        {
 
        }

    }
}
