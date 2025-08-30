using FluentValidation;
using SecretariaEnsino.App.DTO.DtoRequisicao;
using SecretariaEnsino.App.Interface;
using SecretariaEnsino.App.Servico;
using SecretariaEnsino.Infra.Interface;
using SecretariaEnsino.Infra.Servico;
using static SecretariaEnsino.App.DTO.DtoRequisicao.AlunoRequisicao;
using static SecretariaEnsino.App.DTO.DtoRequisicao.MatriculaRequisicao;
using static SecretariaEnsino.App.DTO.DtoRequisicao.TurmaRequisicao;

namespace SecretariaEnsino.API.Configuracao
{
    public static class InjecaoDependencias
    {
        public static IServiceCollection AddInjecaoDependenciasConfiguracao(this IServiceCollection services)
        {
            services.AddScoped<IJwtHandler, JwtHandler>();

            services.AddScoped<IAlunoServico, AlunoServico>();
            services.AddScoped<IAlunoRepositorio, AlunoRepositorio>();
 
            Validator(services);
            return services;
        }

        private static void Validator(IServiceCollection services)
        {
            //todo: utilizar reflexao para resolver as validações 
            services.AddTransient<IValidator<AlunoRequisicao>, AlunoRequisicaoValidator>();
            services.AddTransient<IValidator<MatriculaRequisicao>, MatriculaRequisicaoValidator>();
            services.AddTransient<IValidator<TurmaRequisicao>, TurmaRequisicaoValidator>();
 
        }
    }
}
