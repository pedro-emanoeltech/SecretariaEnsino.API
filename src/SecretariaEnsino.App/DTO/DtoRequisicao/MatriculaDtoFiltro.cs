using SecretariaEnsino.Domain.Enum;

namespace SecretariaEnsino.App.DTO.DtoRequisicao
{
    /// <summary>
    /// Representa os filtros opcionais para buscar matrículas.
    /// </summary>
    public class MatriculaDtoFiltro : BasePaginacaoFiltro
    {
        /// <summary>
        /// Id do aluno vinculado à matrícula.
        /// </summary>
        public Guid? AlunoId { get; set; }

        /// <summary>
        /// Id da turma vinculada à matrícula.
        /// </summary>
        public Guid? TurmaId { get; set; }

        /// <summary>
        /// Nome do aluno (busca parcial).
        /// </summary>
        public string? NomeAluno { get; set; }

        /// <summary>
        /// CPF do aluno.
        /// </summary>
        public string? CpfAluno { get; set; }

        /// <summary>
        /// Email do aluno.
        /// </summary>
        public string? EmailAluno { get; set; }

        /// <summary>
        /// Nome da turma (busca parcial).
        /// </summary>
        public string? NomeTurma { get; set; }

        /// <summary>
        /// Status atual da matrícula.
        /// </summary>
        public StatusMatricula? Status { get; set; }

        /// <summary>
        /// Indica se o certificado foi emitido.
        /// </summary>
        public bool? CertificadoEmitido { get; set; }


    }
}
