using SecretariaEnsino.App.DTO.DtoRequisicao;
using SecretariaEnsino.App.DTO.DtoRespostas;
using SecretariaEnsino.Domain.Entidades;

namespace SecretariaEnsino.App.Interface
{
    public interface ITurmaServico : IBaseService<Turma, TurmaRequisicao, TurmaResposta>
    {

    }
}
