using AutoMapper;
using SecretariaEnsino.App.DTO.DtoRequisicao;
using SecretariaEnsino.Domain.Entidades;

namespace SecretariaEnsino.App.AutoMapper
{
    public class MapperRequisicaoParaDomain : Profile
    {
        public MapperRequisicaoParaDomain()
        {
            CreateMap<AlunoRequisicao, Aluno>(MemberList.Destination)
                .ForMember(dest => dest.Usuario, opt => opt.MapFrom(src => src))
                .IgnoreAllPropertiesWithAnInaccessibleSetter();
 
            CreateMap<AlunoRequisicao, Usuario>(MemberList.Destination)
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email!.ToLower()))
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome))
                .ForMember(dest => dest.Ativo, opt => opt.MapFrom(src => src.Ativo))
                .ForMember(dest => dest.Senha, opt => opt.MapFrom(src => src.Senha))
                .IgnoreAllPropertiesWithAnInaccessibleSetter();

            CreateMap<UsuarioRequisicao, Usuario>(MemberList.Destination)
            .IgnoreAllPropertiesWithAnInaccessibleSetter();

            CreateMap<TurmaRequisicao, Turma>(MemberList.Destination)
                .IgnoreAllPropertiesWithAnInaccessibleSetter();

            CreateMap<MatriculaRequisicao, Matricula>(MemberList.Destination)
                .IgnoreAllPropertiesWithAnInaccessibleSetter();

        }

    }
}
