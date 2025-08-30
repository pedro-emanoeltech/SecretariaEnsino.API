using System.ComponentModel;

namespace SecretariaEnsino.Domain.Enum
{
    public enum StatusMatricula
    {
        [Description("Ativa")]
        Ativa,

        [Description("Trancada")]
        Trancada,

        [Description("Concluída")]
        Concluida,

        [Description("Expirou")]
        Expirou
    }
}
