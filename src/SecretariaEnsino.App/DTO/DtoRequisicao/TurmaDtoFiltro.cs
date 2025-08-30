using SecretariaEnsino.Domain.Abastacao;
using SecretariaEnsino.Domain.Enum;

namespace SecretariaEnsino.App.DTO.DtoRequisicao
{
    /// <summary>
    /// Representa o filtro da turma cadastrada no sistema.
    /// </summary>
    public class TurmaDtoFiltro : IBaseDto
    {
        public string Nome { get; set; }

        public string Descricao { get; set; }

        public StatusTurma Status { get; set; }

    }
}
