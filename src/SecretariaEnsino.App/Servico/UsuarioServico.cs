using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using SecretariaEnsino.App.DTO.DtoRequisicao;
using SecretariaEnsino.App.DTO.DtoRespostas;
using SecretariaEnsino.App.Interface;
using SecretariaEnsino.Domain.Abastacao;
using SecretariaEnsino.Domain.Entidades;
using SecretariaEnsino.Domain.Enum;
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

        public async Task<UsuarioResposta> AdicionarUsuarioAsync(UsuarioRequisicao dtoRequisicao)
        {
            ValidarTipoUsuario(dtoRequisicao.Tipo);
            return await base.AdicionarAsync(dtoRequisicao);
        }

        public override async Task AntesDeAdicionarAsync(Usuario usuario)
        {
            SenhaValida(usuario.Senha);
            EmailValido(usuario.Email);
            await ValidarEmailExistenteAsync(usuario.Email);

            usuario.CriptografarSenha();
            usuario.SetarDataCadastro();
            usuario.Ativo = true;
        }

        public override async Task AntesDeAtualizarAsync(Guid id, Usuario usuario)
        {
            SenhaValida(usuario.Senha);
            EmailValido(usuario.Email);
            await ValidarEmailExistenteAsync(usuario.Email, id);

            usuario.CriptografarSenha();
        }

        public override async Task<bool> Deletar(Guid id)
        {
            var usuario = await _repositorio.BuscarPorId(id).FirstOrDefaultAsync() 
                                ?? throw new NotFoundException("Registro não encontrado");
            ValidarTipoUsuario(usuario!.Tipo);

            await _repositorio.DeletarAsync(id);
            return true;
        }

        private void ValidarTipoUsuario(TipoUsuario tipo)
        {
            var tiposNaoPermitidos = new[] { TipoUsuario.Aluno };

            if (tiposNaoPermitidos.Contains(tipo))
                throw new RegraNegocioException($"O tipo de usuário '{tipo}' não é permitido nesta rota.");
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

        private async Task ValidarEmailExistenteAsync(string email, Guid? excetoId = null)
        {
            var existe = await _repositorio.BuscarTodosPorFiltroAsync(
                u => u.Email.ToLower() == email.ToLower());

            if (existe.Any(u => excetoId == null || u.Id != excetoId))
                throw new RegraNegocioException("O email fornecido já está em uso.");
        }
    }
}
