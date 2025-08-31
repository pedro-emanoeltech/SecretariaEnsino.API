using SecretariaEnsino.Domain.Abastacao;
using SecretariaEnsino.Domain.Enum;

namespace SecretariaEnsino.Domain.Entidades
{
    /// <summary>
    /// Representa a matrícula de um aluno em uma turma.
    /// </summary>
    public class Matricula : BaseEntidade
    {
        /// <summary>
        /// Id do aluno matriculado.
        /// </summary>
        public Guid AlunoId { get; set; }

        /// <summary>
        /// Id da turma vinculada.
        /// </summary>
        public Guid TurmaId { get; set; }

        /// <summary>
        /// Data em que a matrícula foi realizada.
        /// </summary>
        public DateTime DataMatricula { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Status da matrícula (Ativa, Trancada, Concluída, Expirou).
        /// </summary>
        public StatusMatricula Status { get; set; }

        /// <summary>
        /// Nota ou média final do aluno na turma.
        /// </summary>
        public decimal? NotaFinal { get; set; }

        /// <summary>
        /// Indica se o certificado foi emitido.
        /// </summary>
        public bool CertificadoEmitido { get; set; }

        /// <summary>
        /// Turma relacionada à matrícula.
        /// </summary>
        public Turma Turma { get; set; }

        /// <summary>
        /// Aluno relacionado à matrícula.
        /// </summary>
        public Aluno Aluno { get; set; }

    }
}
