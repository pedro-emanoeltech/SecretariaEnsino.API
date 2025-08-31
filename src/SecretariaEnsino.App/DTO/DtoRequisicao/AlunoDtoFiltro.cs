namespace SecretariaEnsino.App.DTO.DtoRequisicao
{
    /// <summary>
    /// Representa os filtros opcionais para buscar alunos.
    /// </summary>
    public class AlunoDtoFiltro : BasePaginacaoFiltro
    {
        /// <summary>
        /// Nome do aluno
        /// </summary>
        public string? Nome { get; set; }

        /// <summary>
        /// CPF do aluno
        /// </summary>
        public string? Cpf { get; set; }

        /// <summary>
        /// Email do aluno.
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// Indica se o aluno está ativo.
        /// </summary>
        public bool? Ativo { get; set; }
    }

}
