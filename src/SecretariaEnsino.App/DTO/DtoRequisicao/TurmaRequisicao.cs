using FluentValidation;
using SecretariaEnsino.Domain.Abastacao;
using SecretariaEnsino.Domain.Enum;

namespace SecretariaEnsino.App.DTO.DtoRequisicao
{
    public class TurmaRequisicao : BaseEntidade
    {
        public string Nome { get; set; }  
        public string? Descricao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public int Capacidade { get; set; }
        public string? Professor { get; set; }
        public StatusTurma Status { get; set; }

        public class TurmaRequisicaoValidator : AbstractValidator<TurmaRequisicao>
        {
            public TurmaRequisicaoValidator()
            {
                RuleFor(banco => banco.Nome)
                    .NotNull().NotEmpty().WithMessage("É obrigatório informar Id do Aluno.");

                RuleFor(banco => banco.DataInicio)
                    .NotNull().NotEmpty().WithMessage("É obrigatório informar Id da Turma.");

            }
        }
    }
}
