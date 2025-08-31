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
            CreateMap<Aluno, AlunoResposta>(MemberList.Destination);
            CreateMap<Turma, TurmaResposta>(MemberList.Destination);
            CreateMap<Matricula, MatriculaResposta>(MemberList.Destination);

            CreateMap<TokenAcesso, LoginResposta>(MemberList.Destination);
        }

    }
}
