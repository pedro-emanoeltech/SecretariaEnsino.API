using Microsoft.EntityFrameworkCore;
using SecretariaEnsino.Infra.Contexto;

namespace SecretariaEnsino.API.Configuracao
{
    public static class ContextoConfiguracao
    {
        public static IServiceCollection AddContextoConfiguracao<TContext>(this IServiceCollection services,
            IConfiguration configuration) where TContext : BaseContexto
        {
            services.AddDbContext<TContext>(options =>
            {
                options.UseLoggerFactory(LoggerFactory.Create(build => build.AddConsole()));
                options.UseSqlServer(configuration.GetConnectionString("ConnectionStrings:BaseSqlServer"),
                    sqlOptions =>
                    {
                        sqlOptions.EnableRetryOnFailure(
                            maxRetryCount: 3,
                            maxRetryDelay: TimeSpan.FromSeconds(5),
                            errorNumbersToAdd: null
                        );
                    });
                options.EnableDetailedErrors().EnableSensitiveDataLogging();
            });

            return services;
        }

        public static IApplicationBuilder ConfiguracaoEscopoSqlServer<TContext>(this IApplicationBuilder app) where TContext : BaseContexto
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetRequiredService<TContext>();
                dbContext.Database.Migrate();
            }
            return app;
        }
    }
}
