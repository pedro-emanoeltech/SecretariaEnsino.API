using SecretariaEnsino.Domain.Abastacao;

namespace SecretariaEnsino.App.DTO.DtoRespostas
{
    public class LoginResposta : IBaseDto
    {
        public string? Token { get; set; }
        public DateTime? DataExpiracao { get; set; }
    }
}
