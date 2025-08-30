using SecretariaEnsino.Domain.Abastacao;

namespace SecretariaEnsino.App.DTO.DtoRequisicao
{
    /// <summary>
    /// Representa um filtro do aluno cadastrado no sistema.
    /// </summary>
    public class AlunoDtoFiltro : IBaseDto
    {
        public string Nome { get; set; }

        public string Cpf { get; set; }

        public string Email { get; set; }

        public bool Ativo { get; set; }

    }
}
