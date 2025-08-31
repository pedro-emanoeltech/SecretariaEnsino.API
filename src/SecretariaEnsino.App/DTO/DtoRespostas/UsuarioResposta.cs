using SecretariaEnsino.Domain.Abastacao;
using SecretariaEnsino.Domain.Enum;

namespace SecretariaEnsino.App.DTO.DtoRespostas
{
    public class UsuarioResposta : IBaseDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime DataCadastro { get; set; }
        public TipoUsuario Tipo { get; set; }
        public bool Ativo { get; set; }
    }
}
