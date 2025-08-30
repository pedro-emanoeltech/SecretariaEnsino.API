using System.ComponentModel;

namespace SecretariaEnsino.Domain.Enum
{ 
    public enum StatusTurma
    {
        [Description("Aberta")]
        Aberta,

        [Description("Em andamento")]
        EmAndamento,

        [Description("Encerrada")]
        Encerrada,

        [Description("Cancelada")]
        Cancelada
    }
}
