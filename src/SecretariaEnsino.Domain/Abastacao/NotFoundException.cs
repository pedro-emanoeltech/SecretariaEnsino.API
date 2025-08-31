using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SecretariaEnsino.Domain.Abastacao
{
    /// <summary>
    /// abastracao para registro nao localizado.
    /// </summary>
    public class NotFoundException : Exception
    {
        public NotFoundException() { }
        public NotFoundException(string message) : base(message) { }
    }
}



