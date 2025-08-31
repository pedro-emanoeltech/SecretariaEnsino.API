using SecretariaEnsino.Domain.Enum;

namespace SecretariaEnsino.App.DTO.DtoRequisicao
{
    /// <summary>
    /// Representa os filtros opcionais para buscar turmas.
    /// </summary>
    public class TurmaDtoFiltro : BasePaginacaoFiltro
    {
        /// <summary>
        /// Nome da turma 
        /// </summary>
        public string? Nome { get; set; }

        /// <summary>
        /// Descrição da turma  
        /// </summary>
        public string? Descricao { get; set; }

        /// <summary>
        /// Nome do professor responsável pela turma.
        /// </summary>
        public string? Professor { get; set; }

        /// <summary>
        /// Status atual da turma.
        /// </summary>
        public StatusTurma? Status { get; set; }
    }

}
