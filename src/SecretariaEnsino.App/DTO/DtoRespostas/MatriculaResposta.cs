using SecretariaEnsino.Domain.Abastacao;
using SecretariaEnsino.Domain.Enum;

namespace SecretariaEnsino.App.DTO.DtoRespostas
{
    /// <summary>
    /// Representa a matrícula de um aluno em uma turma.
    /// </summary>
    public class MatriculaResposta : IBaseDto
    {
        public Guid Id { get; set; }
        public Guid AlunoId { get; set; }
        public Guid TurmaId { get; set; }
        public string NomeAluno { get; set; }
        public string CpfAluno { get; set; }
        public string NomeTurma { get; set; }
        public DateTime DataMatricula { get; set; }
        public StatusMatricula Status { get; set; }
        public decimal? NotaFinal { get; set; }
        public bool CertificadoEmitido { get; set; }
    }
}
