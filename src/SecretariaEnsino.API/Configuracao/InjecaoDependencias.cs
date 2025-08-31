using FluentValidation;
using SecretariaEnsino.App.DTO.DtoRequisicao;
using SecretariaEnsino.App.Interface;
using SecretariaEnsino.App.Servico;
using SecretariaEnsino.Infra.Interface;
using SecretariaEnsino.Infra.Servico;
using static SecretariaEnsino.App.DTO.DtoRequisicao.AlunoRequisicao;
using static SecretariaEnsino.App.DTO.DtoRequisicao.LoginRequisicao;
using static SecretariaEnsino.App.DTO.DtoRequisicao.MatriculaRequisicao;
using static SecretariaEnsino.App.DTO.DtoRequisicao.TurmaRequisicao;
using static SecretariaEnsino.App.DTO.DtoRequisicao.UsuarioRequisicao;

namespace SecretariaEnsino.API.Configuracao
{
    public static class InjecaoDependencias
    {
        public static IServiceCollection AddInjecaoDependenciasConfiguracao(this IServiceCollection services)
        {
            //repositorio
            services.AddScoped<IMatriculaRepositorio, MatriculaRepositorio>();
            services.AddScoped<IAlunoRepositorio, AlunoRepositorio>();
            services.AddScoped<ITurmaRepositorio, TurmaRepositorio>();
            services.AddScoped<IUsuarioRepositorio,UsuarioRepositorio>();
             
            //serviços
            services.AddScoped<IJwtHandlerServico, JwtHandlerServico>();
            services.AddScoped<IAlunoServico, AlunoServico>();
            services.AddScoped<IMatriculaServico, MatriculaServico>();
            services.AddScoped<ITurmaServico, TurmaServico>();
            services.AddScoped<IAutenticacaoServico, AutenticacaoServico>();
            services.AddScoped<IUsuarioServico, UsuarioServico>();
        
 
            Validator(services);
            return services;
        }

        private static void Validator(IServiceCollection services)
        {
            //todo: utilizar reflexao para resolver as validações 
            services.AddTransient<IValidator<AlunoRequisicao>, AlunoRequisicaoValidator>();
            services.AddTransient<IValidator<MatriculaRequisicao>, MatriculaRequisicaoValidator>();
            services.AddTransient<IValidator<TurmaRequisicao>, TurmaRequisicaoValidator>();
            services.AddTransient<IValidator<LoginRequisicao>, LoginRequisicaoValidator>();
            services.AddTransient<IValidator<UsuarioRequisicao>, UsuarioRequisicaoValidator>();
 
        }
    }
}
