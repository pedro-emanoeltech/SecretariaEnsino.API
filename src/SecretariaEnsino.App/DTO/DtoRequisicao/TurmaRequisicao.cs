using FluentValidation;
using SecretariaEnsino.Domain.Abastacao;
using SecretariaEnsino.Domain.Enum;

namespace SecretariaEnsino.App.DTO.DtoRequisicao
{
    public class TurmaRequisicao : IBaseDto
    {
        public string Nome { get; set; }  
        public string Descricao { get; set; }
        public DateTime? DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public int? Capacidade { get; set; }
        public string? Professor { get; set; }
        public StatusTurma Status { get; set; }

        public class TurmaRequisicaoValidator : AbstractValidator<TurmaRequisicao>
        {
            public TurmaRequisicaoValidator()
            {
                RuleFor(x => x.Nome)
                    .NotEmpty().WithMessage("É obrigatório informar o Nome da turma")
                    .MinimumLength(3).WithMessage("O Nome da turma deve ter pelo menos 3 caracteres");

                RuleFor(x => x.Descricao)
                    .MinimumLength(3).When(x => !string.IsNullOrEmpty(x.Descricao))
                    .WithMessage("A Descrição da turma deve ter pelo menos 3 caracteres");

                RuleFor(x => x.Capacidade)
                  .NotNull().WithMessage("É obrigatório informar a Capacidade da turma")
                  .GreaterThan(0).WithMessage("A capacidade da turma deve ser maior que zero");

                RuleFor(x => x.DataFim)
                    .GreaterThan(x => x.DataInicio.Value)
                    .When(x => x.DataInicio.HasValue && x.DataFim.HasValue)
                    .WithMessage("A data de fim deve ser posterior à data de início");

                RuleFor(x => x.Professor)
                    .MinimumLength(3)
                    .When(x => !string.IsNullOrWhiteSpace(x.Professor))
                    .WithMessage("O nome do professor deve ter pelo menos 3 caracteres");
            }
        }
    }
}
