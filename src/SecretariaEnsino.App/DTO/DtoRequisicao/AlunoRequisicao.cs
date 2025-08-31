using FluentValidation;
using System.Text.RegularExpressions;

namespace SecretariaEnsino.App.DTO.DtoRequisicao
{
    public class AlunoRequisicao : BaseUsuarioRequisicao
    {
        public DateTime DataNascimento { get; set; }
        public string Cpf { get; set; }
        public string? Telefone { get; set; }

        public class AlunoRequisicaoValidator : AbstractValidator<AlunoRequisicao>
        {
            public AlunoRequisicaoValidator()
            {
                var baseValidator = new BaseUsuarioRequisicaoValidator();
                Include(baseValidator);

                RuleFor(x => x.Cpf)
                    .NotEmpty().WithMessage("CPF é obrigatório")
                    .Must(ValidarCpf).WithMessage("CPF inválido");
            }

            private bool ValidarCpf(string cpf)
            {
                if (string.IsNullOrWhiteSpace(cpf))
                    return false;

 
                cpf = Regex.Replace(cpf, "[^0-9]", "");
                if (cpf.Length != 11)
                    return false;

                return true;
            }
        }
    }
}
