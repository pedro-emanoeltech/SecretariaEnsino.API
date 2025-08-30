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
               .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email!.ToLower()));

        }

    }
}
