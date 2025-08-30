using AutoMapper;
using SecretariaEnsino.App.DTO.DtoRespostas;
using SecretariaEnsino.Domain.Entidades;

namespace SecretariaEnsino.App.AutoMapper
{
    public class MapperDomainParaResposta : Profile
    {
        public MapperDomainParaResposta()
        {
            CreateMap<Aluno, AlunoResposta>(MemberList.Destination);
        }

    }
}
