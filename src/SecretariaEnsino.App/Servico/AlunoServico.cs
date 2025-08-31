using AutoMapper;
using FluentValidation;
using SecretariaEnsino.App.DTO.DtoRequisicao;
using SecretariaEnsino.App.DTO.DtoRespostas;
using SecretariaEnsino.App.Interface;
using SecretariaEnsino.Domain.Abastacao;
using SecretariaEnsino.Domain.Entidades;
using SecretariaEnsino.Domain.Enum;
using SecretariaEnsino.Infra.Interface;

namespace SecretariaEnsino.App.Servico
{
    public class AlunoServico : BaseServico<Aluno, AlunoRequisicao, AlunoResposta>, IAlunoServico
    {
        private readonly IAlunoRepositorio _repositorio;
        private readonly IUsuarioServico _usuarioServico;

        public AlunoServico(
            IMapper mapper,
            IAlunoRepositorio repositorio,
            IValidator<AlunoRequisicao> validator,
            IUsuarioServico usuarioServico)
            : base(repositorio, mapper, validator)
        {
            _repositorio = repositorio;
            _usuarioServico = usuarioServico;
        }

        protected override async Task AntesDeAdicionarAsync(Aluno aluno)
        {
            await ValidarCpfExistenteAsync(aluno.Cpf);

            var usuarioDto = new UsuarioRequisicao
            {
                Nome = aluno.Usuario.Nome,
                Email = aluno.Usuario.Email,
                Senha = aluno.Usuario.Senha,
                Tipo = TipoUsuario.Aluno,
                Ativo = true
            };

            var usuarioCriado = await _usuarioServico.AdicionarAsync(usuarioDto);
            aluno.UsuarioId = usuarioCriado.Id;
        }

        public async Task ValidarCpfExistenteAsync(string cpf)
        {
            var existe = await _repositorio.BuscarTodosPorFiltroAsync(
                u => u.Cpf.ToLower() == cpf.ToLower()
            );

            if (existe.Any())
                throw new RegraNegocioException("O CPF fornecido já está em uso.");
        }

    }
}
