using FluentValidation;
using SecretariaEnsino.Domain.Abastacao;

namespace SecretariaEnsino.App.DTO.DtoRequisicao
{
    public class MatriculaRequisicao : IBaseDto
    {
        public Guid AlunoId { get; set; }
        public Guid TurmaId { get; set; }

        public class MatriculaRequisicaoValidator : AbstractValidator<MatriculaRequisicao>
        {
            public MatriculaRequisicaoValidator()
            {
                RuleFor(banco => banco.AlunoId)
                    .NotNull().NotEmpty().WithMessage("É obrigatório informar Id do Aluno.");
               
                RuleFor(banco => banco.TurmaId)
                    .NotNull().NotEmpty().WithMessage("É obrigatório informar Id da Turma.");

            }
        }
    }
}
