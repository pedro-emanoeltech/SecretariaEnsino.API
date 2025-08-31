using System.ComponentModel;

namespace SecretariaEnsino.Domain.Enum
{
    public enum TipoUsuario
    {
        [Description("Administrador")]
        Administrador,

        [Description("Professor")]
        Professor,

        [Description("Aluno")]
        Aluno
    }
}
