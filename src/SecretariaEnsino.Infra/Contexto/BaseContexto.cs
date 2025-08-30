using Microsoft.EntityFrameworkCore;

namespace SecretariaEnsino.Infra.Contexto
{
    public class BaseContexto : DbContext
    {
        public BaseContexto(DbContextOptions options) : base(options)
        {
      
        }
    }
}
