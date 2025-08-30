using SecretariaEnsino.Domain.Abastacao;
using SecretariaEnsino.Domain.Enum;

namespace SecretariaEnsino.App.DTO.DtoRequisicao
{
    /// <summary>
    /// Representa o filtro da matrícula de um aluno em uma turma.
    /// </summary>
    public class MatriculaDtoFiltro : IBaseDto
    {
 
        public Guid AlunoId { get; set; }
 
        public Guid TurmaId { get; set; }
 
        public StatusMatricula Status { get; set; } 
  
        public bool CertificadoEmitido { get; set; }  
  
    }
}
