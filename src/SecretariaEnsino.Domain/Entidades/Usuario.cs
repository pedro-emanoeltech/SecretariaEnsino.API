using SecretariaEnsino.Domain.Abastacao;
using SecretariaEnsino.Domain.Enum;

namespace SecretariaEnsino.Domain.Entidades
{
    /// <summary>
    /// Representa um Usuario cadastrado no sistema.
    /// </summary>
    public class Usuario : BaseEntidade
    {
        /// <summary>
        /// Nome Completo do usuario.
        /// </summary>
        public string? Nome { get; set; }

        /// <summary>
        /// Obtém ou define o Email da usuario.
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// Obtém ou define o senha do usuario
        /// </summary>
        public string? Senha { get; set; }

        /// <summary>
        /// Obtém ou define o o tipo de usuario .
        /// </summary>
        public TipoUsuario Tipo { get; set; }

        /// <summary>
        /// Indica se o usuario está ativo ou inativo.
        /// </summary>
        public bool Ativo { get; set; }

        /// <summary>
        /// Data em que o usuario foi cadastrado no sistema.
        /// </summary>
        public DateTime DataCadastro { get; set; }


        /// <summary>
        /// Usuario pode ou nao estar vinculado ao aluno.
        /// </summary>
        public Aluno? Aluno { get; set; }

        //futuramente implementar logica de professor e administrador se quiser
    }
}
