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

            }
        }
    }
}
