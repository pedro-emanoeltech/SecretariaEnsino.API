using AutoMapper;
using SecretariaEnsino.App.DTO.DtoRequisicao;
using SecretariaEnsino.Domain.Entidades;

namespace SecretariaEnsino.App.AutoMapper
{
    public class MapperRequisicaoParaDomain : Profile
    {
        public MapperRequisicaoParaDomain()
        {
            CreateMap<AlunoRequisicao, Aluno>(MemberList.Destination);
            CreateMap<AlunoRequisicao, Usuario>(MemberList.Destination);
            CreateMap<TurmaRequisicao, Turma>(MemberList.Destination);
            CreateMap<MatriculaRequisicao, Matricula>(MemberList.Destination);
 
        }

    }
}
