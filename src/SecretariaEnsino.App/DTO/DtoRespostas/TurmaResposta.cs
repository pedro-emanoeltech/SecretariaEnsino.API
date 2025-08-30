using SecretariaEnsino.Domain.Abastacao;
using SecretariaEnsino.Domain.Enum;

namespace SecretariaEnsino.App.DTO.DtoRespostas
{
    public class TurmaResposta : IBaseDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string? Descricao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public int Capacidade { get; set; }
        public string? Professor { get; set; }
        public StatusTurma Status { get; set; }
    }
}
