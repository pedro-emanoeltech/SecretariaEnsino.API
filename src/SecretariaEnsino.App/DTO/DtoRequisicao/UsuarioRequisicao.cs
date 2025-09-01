using FluentValidation;
using SecretariaEnsino.Domain.Enum;

namespace SecretariaEnsino.App.DTO.DtoRequisicao
{
    public class UsuarioRequisicao : BaseUsuarioRequisicao
    {
        public TipoUsuario Tipo { get; set; }

        public class UsuarioRequisicaoValidator : AbstractValidator<UsuarioRequisicao>
        {
            public UsuarioRequisicaoValidator()
            {
                var baseValidator = new BaseUsuarioRequisicaoValidator();
                Include(baseValidator);

                RuleFor(x => x.Tipo)
                    .NotNull()
                    .WithMessage("É obrigatório informar Tipo de Usuario");
  
            }
        }
    }
}
