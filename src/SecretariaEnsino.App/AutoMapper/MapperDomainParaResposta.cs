using AutoMapper;
using SecretariaEnsino.App.DTO.DtoModelo;
using SecretariaEnsino.App.DTO.DtoRespostas;
using SecretariaEnsino.Domain.Entidades;

namespace SecretariaEnsino.App.AutoMapper
{
    public class MapperDomainParaResposta : Profile
    {
        public MapperDomainParaResposta()
        {
            CreateMap<Aluno, AlunoResposta>(MemberList.Destination)
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Usuario.Email))
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Usuario.Nome))
                .ForMember(dest => dest.Ativo, opt => opt.MapFrom(src => src.Usuario.Ativo))
                .IgnoreAllPropertiesWithAnInaccessibleSetter();

            CreateMap<Usuario, UsuarioResposta>(MemberList.Destination);

            CreateMap<Turma, TurmaResposta>(MemberList.Destination)
                .ForMember(dest => dest.TotalAlunosMatriculados, opt => opt.MapFrom(src => src.Matriculas.Count))
                .IgnoreAllPropertiesWithAnInaccessibleSetter();

            CreateMap<Matricula, MatriculaResposta>(MemberList.Destination)
                 .ForMember(dest => dest.NomeTurma, opt => opt.MapFrom(src => src.Turma.Nome))
                 .ForMember(dest => dest.NomeAluno, opt => opt.MapFrom(src => src.Aluno.Usuario.Nome))
                 .ForMember(dest => dest.CpfAluno, opt => opt.MapFrom(src => src.Aluno.Cpf))
                .IgnoreAllPropertiesWithAnInaccessibleSetter();

            CreateMap<TokenAcesso, LoginResposta>(MemberList.Destination);
        }

    }
}
