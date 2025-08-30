namespace SecretariaEnsino.Domain.Abastacao
{
    /// <summary>
    /// Entidade base response de requisição.
    /// </summary>

    public class Resultado<T> : IBaseDto, IResultado
    {
        public T? Data { get; set; }
        public string? Message { get; set; }

        public static IResultado New(T? data, string? message = null)
        {
            return new Resultado<T>
            {
                Data = data,
                Message = message
            };
        }
 
        public static IResultado SuccessMessage(string message)
        {
            return new Resultado<T>
            {
                Data = default,
                Message = message
            };
        }
    }


}



