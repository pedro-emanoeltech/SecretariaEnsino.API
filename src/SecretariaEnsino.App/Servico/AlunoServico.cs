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

        public override async Task AntesDeAdicionarAsync(Aluno aluno)
        {
            await ValidarCpfExistenteAsync(aluno.Cpf);
            await _usuarioServico.AntesDeAdicionarAsync(aluno.Usuario);
            aluno.Usuario.Tipo = TipoUsuario.Aluno;
            aluno.Usuario.Ativo = true;
        }

        public override async Task AntesDeAtualizarAsync(Guid id, Aluno aluno)
        {
            await ValidarCpfExistenteAsync(aluno.Cpf, id);
            await _usuarioServico.AntesDeAtualizarAsync(aluno.Usuario.Id!.Value, aluno.Usuario);
            aluno.Usuario.Tipo = TipoUsuario.Aluno;
        }

        public async Task ValidarCpfExistenteAsync(string cpf, Guid? excetoId = null)
        {
            var existe = await _repositorio.BuscarTodosPorFiltroAsync(
                u => u.Cpf.ToLower() == cpf.ToLower()
            );

            if (existe.Any(u => excetoId == null || u.Id != excetoId))
                throw new RegraNegocioException("O CPF fornecido já está em uso.");
        }

    }
}
