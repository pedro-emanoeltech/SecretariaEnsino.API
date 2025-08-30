using SecretariaEnsino.Domain.Abastacao;

namespace SecretariaEnsino.Domain.Entidades
{
    /// <summary>
    /// Representa um aluno cadastrado no sistema.
    /// </summary>
    public class Aluno : BaseEntidade
    {
        /// <summary>
        /// Nome completo do aluno.
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// Data de nascimento do aluno.
        /// </summary>
        public DateTime DataNascimento { get; set; }

        /// <summary>
        /// CPF do aluno (11 dígitos).
        /// </summary>
        public string Cpf { get; set; }

        /// <summary>
        /// Endereço de e-mail do aluno.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Senha criptografada do aluno.
        /// </summary>
        public string SenhaHash { get; set; }

        /// <summary>
        /// Telefone ou celular do aluno.
        /// </summary>
        public string? Telefone { get; set; }

        /// <summary>
        /// Data em que o aluno foi cadastrado no sistema.
        /// </summary>
        public DateTime DataCadastro { get; set; }  

        /// <summary>
        /// Indica se o aluno está ativo ou inativo.
        /// </summary>
        public bool Ativo { get; set; }  

        /// <summary>
        /// Matrículas associadas a este aluno.
        /// </summary>
        public ICollection<Matricula> Matriculas { get; set; } = new List<Matricula>();
    }
}
