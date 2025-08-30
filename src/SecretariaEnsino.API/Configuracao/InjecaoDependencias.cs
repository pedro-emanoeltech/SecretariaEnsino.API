using SecretariaEnsino.App.Interface;
using SecretariaEnsino.App.Servico;

namespace SecretariaEnsino.API.Configuracao
{
    public static class InjecaoDependencias
    {
        public static IServiceCollection AddInjecaoDependenciasConfiguracao(this IServiceCollection services)
        {
            services.AddScoped<IJwtHandler, JwtHandler>();
            //services.AddScoped<IAuditoriaRepository, AuditoriaRepository>();
            //services.AddScoped<IAuditoriaService, AuditoriaService>();
            //services.AddScoped<IAuditoriaServiceApp, AuditoriaServiceApp>();

            Validator(services);
            return services;
        }

        private static void Validator(IServiceCollection services)
        {
            ///todo: utilizar reflexao para resolver as validações 
            //services.AddTransient<IValidator<CobrancaRequest>, CobrancaRequestValidator>();
 
        }
    }
}
