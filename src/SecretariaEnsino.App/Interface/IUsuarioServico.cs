using SecretariaEnsino.App.DTO.DtoRequisicao;
using SecretariaEnsino.App.DTO.DtoRespostas;
using SecretariaEnsino.Domain.Entidades;

namespace SecretariaEnsino.App.Interface
{
    public interface IUsuarioServico : IBaseService<Usuario, UsuarioRequisicao, UsuarioResposta>
    {
        Task ValidarEmailExistenteAsync(string email);
    }
}
