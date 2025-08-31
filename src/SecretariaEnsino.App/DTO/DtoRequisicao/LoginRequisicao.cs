using FluentValidation;
using SecretariaEnsino.Domain.Abastacao;

namespace SecretariaEnsino.App.DTO.DtoRequisicao
{
    public class LoginRequisicao : IBaseDto
    {
        /// <summary>
        /// Obtém ou define o Email da conta.
        /// </summary>
        /// <example>fulano@qq.com</example>
        public string? Email { get; set; }

        public string? Senha { get; set; }

        public class LoginRequisicaoValidator : AbstractValidator<LoginRequisicao>
        {
            public LoginRequisicaoValidator()
            {
                RuleFor(banco => banco.Email)
                    .NotNull().NotEmpty().WithMessage("É obrigatório informar Email do usuario");

                RuleFor(banco => banco.Senha)
                    .NotNull().NotEmpty().WithMessage("É obrigatório informar senha do usuario.");

            }
        }
    }
}
