namespace SecretariaEnsino.App.DTO.DtoModelo
{
    public class TokenAcesso
    {
        public TokenAcesso(string? token, DateTime? dataExpiracao)
        {
            Token = token;
            DataExpiracao = dataExpiracao;
        }

        public string? Token { get; private set; }
        public DateTime? DataExpiracao { get; set; }
    }
}
