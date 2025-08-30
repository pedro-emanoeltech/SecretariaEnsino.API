namespace SecretariaEnsino.API.Configuracao
{
    public static class AutoMapperConfiguracao
    {
        public static IServiceCollection AddAutoMapperConfiguracao(this IServiceCollection services)
        {
            //services.AddAutoMapper(typeof(DomainToResponseMapper));
         
            return services;
        }
    }
}
