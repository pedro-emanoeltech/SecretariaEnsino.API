using AutoMapper;
using FluentValidation;
using SecretariaEnsino.App.DTO.DtoRequisicao;
using SecretariaEnsino.App.DTO.DtoRespostas;
using SecretariaEnsino.App.Interface;
using SecretariaEnsino.Domain.Entidades;
using SecretariaEnsino.Infra.Interface;

namespace SecretariaEnsino.App.Servico
{
    public class UsuarioServico : BaseServico<Usuario, UsuarioRequisicao, UsuarioResposta>, IUsuarioServico
    {
        public UsuarioServico(
            IMapper mapper,
            IUsuarioRepositorio repositorio,
            IValidator<UsuarioRequisicao> validator)
            : base(repositorio, mapper, validator)
        {
 
        }

    }
}
