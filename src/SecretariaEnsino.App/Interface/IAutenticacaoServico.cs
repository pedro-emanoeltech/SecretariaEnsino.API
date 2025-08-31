using SecretariaEnsino.App.DTO.DtoRequisicao;
using SecretariaEnsino.App.DTO.DtoRespostas;

namespace SecretariaEnsino.App.Interface
{
    public interface IAutenticacaoServico
    {
        Task<LoginResposta> Login(LoginRequisicao loginRequisicao);
    }
}
