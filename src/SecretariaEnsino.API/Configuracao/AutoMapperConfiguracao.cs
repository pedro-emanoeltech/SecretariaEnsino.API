using SecretariaEnsino.App.AutoMapper;

namespace SecretariaEnsino.API.Configuracao
{
    public static class AutoMapperConfiguracao
    {
        public static IServiceCollection AddAutoMapperConfiguracao(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MapperRequisicaoParaDomain));
            services.AddAutoMapper(typeof(MapperDomainParaResposta));
         
            return services;
        }
    }
}
