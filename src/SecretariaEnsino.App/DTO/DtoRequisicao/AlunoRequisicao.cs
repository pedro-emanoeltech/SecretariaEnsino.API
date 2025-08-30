using FluentValidation;
using SecretariaEnsino.Domain.Abastacao;

namespace SecretariaEnsino.App.DTO.DtoRequisicao
{
 
    public class AlunoRequisicao : IBaseDto
    {
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string? Telefone { get; set; }
        public bool Ativo { get; set; }

        public class AlunoRequisicaoValidator : AbstractValidator<AlunoRequisicao>
        {
            public AlunoRequisicaoValidator()
            {
                RuleFor(banco => banco.Email)
                    .NotNull().NotEmpty().WithMessage("É obrigatório informar Email da conta");

            }
        }
    }
}
