using SecretariaEnsino.Domain.Abastacao;
using SecretariaEnsino.Domain.Enum;

namespace SecretariaEnsino.Domain.Entidades
{
    /// <summary>
    /// Representa uma turma cadastrada no sistema.
    /// </summary>
    public class Turma : BaseEntidade
    {
        /// <summary>
        /// Nome da turma.
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// Descrição da turma.
        /// </summary>
        public string? Descricao { get; set; }

        /// <summary>
        /// Data de início da turma.
        /// </summary>
        public DateTime DataInicio { get; set; }

        /// <summary>
        /// Data de término da turma.
        /// </summary>
        public DateTime? DataFim { get; set; }

        /// <summary>
        /// Número máximo de alunos na turma.
        /// </summary>
        public int Capacidade { get; set; }

        /// <summary>
        /// Nome do professor responsável pela turma.
        /// </summary>
        public string? Professor { get; set; }

        /// <summary>
        /// Situação da turma (Aberta, Em andamento, Encerrada).
        /// </summary>
        public StatusTurma Status { get; set; } 

        /// <summary>
        /// Matrículas associadas a esta turma.
        /// </summary>
        public ICollection<Matricula> Matriculas { get; set; } = new List<Matricula>();
    }
}
