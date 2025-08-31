using AutoMapper;
using FluentValidation;
using SecretariaEnsino.App.DTO.DtoRequisicao;
using SecretariaEnsino.App.DTO.DtoRespostas;
using SecretariaEnsino.App.Interface;
using SecretariaEnsino.Domain.Abastacao;
using SecretariaEnsino.Domain.Entidades;
using SecretariaEnsino.Infra.Interface;
using System.ComponentModel.DataAnnotations;

namespace SecretariaEnsino.App.Servico
{
    public class UsuarioServico : BaseServico<Usuario, UsuarioRequisicao, UsuarioResposta>, IUsuarioServico
    {
        private readonly IUsuarioRepositorio _repositorio;
        public UsuarioServico(
            IMapper mapper,
            IUsuarioRepositorio repositorio,
            IValidator<UsuarioRequisicao> validator)
            : base(repositorio, mapper, validator)
        {
            _repositorio = repositorio;
        }

        protected override async Task AntesDeAdicionarAsync(Usuario usuario)
        {
            SenhaValida(usuario.Senha);
            EmailValido(usuario.Email);
            await ValidarEmailExistenteAsync(usuario.Email);

            usuario.CriptografarSenha();
        }

        private void SenhaValida(string senha)
        {
            if (string.IsNullOrWhiteSpace(senha) || senha.Length < 8 ||
                !senha.Any(char.IsUpper) || !senha.Any(char.IsLower) ||
                !senha.Any(char.IsDigit) || !senha.Any(ch => !char.IsLetterOrDigit(ch)))
            {
                throw new RegraNegocioException("A senha deve ter no mínimo 8 caracteres, incluindo letras maiúsculas, minúsculas, números e símbolos especiais.");
            }
        }

        private void EmailValido(string email)
        {
            if (string.IsNullOrWhiteSpace(email) || !new EmailAddressAttribute().IsValid(email))
            {
                throw new RegraNegocioException("O email fornecido é inválido.");
            }
        }

        public async Task ValidarEmailExistenteAsync(string email)
        {
            var existe = await _repositorio.BuscarTodosPorFiltroAsync(
                  u => u.Email.ToLower() == email.ToLower());

            if (existe.Any())
                throw new RegraNegocioException("O email fornecido já está em uso.");
        }
    }
}
