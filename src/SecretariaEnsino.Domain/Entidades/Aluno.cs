using SecretariaEnsino.Domain.Abastacao;

namespace SecretariaEnsino.Domain.Entidades
{
    /// <summary>
    /// Representa um aluno cadastrado no sistema.
    /// </summary>
    public class Aluno : BaseEntidade
    {
        /// <summary>
        /// Id do Usuario.
        /// </summary>
        public Guid UsuarioId { get; set; }

        /// <summary>
        /// Data de nascimento do aluno.
        /// </summary>
        public DateTime DataNascimento { get; set; }

        /// <summary>
        /// CPF do aluno (11 dígitos)
        /// </summary>
        public string Cpf { get; set; }

        /// <summary>
        /// Telefone ou celular do aluno.
        /// </summary>
        public string? Telefone { get; set; }

        /// <summary>
        /// Matrículas associadas a este aluno.
        /// </summary>
        public ICollection<Matricula>? Matriculas { get; set; }

        /// <summary>
        /// Matrículas associadas a este aluno.
        /// </summary>
        public Usuario Usuario { get; set; } = new Usuario();
    }
}
