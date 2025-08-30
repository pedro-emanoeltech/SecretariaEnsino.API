using SecretariaEnsino.App.DTO.DtoRequisicao;
using SecretariaEnsino.App.DTO.DtoRespostas;
using SecretariaEnsino.Domain.Entidades;

namespace SecretariaEnsino.App.Interface
{
    public interface IAlunoServico : IBaseService<Aluno, AlunoRequisicao, AlunoResposta>
    {

    }
}
