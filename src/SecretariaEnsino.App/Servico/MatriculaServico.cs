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
    public class MatriculaServico : BaseServico<Matricula, MatriculaRequisicao, MatriculaResposta>, IMatriculaServico
    {
        private readonly IMatriculaRepositorio _repositorio;

        public MatriculaServico(
            IMapper mapper,
            IMatriculaRepositorio repositorio,
            IValidator<MatriculaRequisicao> validator)
            : base(repositorio, mapper, validator)
        {
            _repositorio = repositorio;
        }

        protected override async Task AntesDeAdicionarAsync(Matricula matricula)
        {
            await ValidarAlunoJaMatriculado(matricula);
        }

        private async Task ValidarAlunoJaMatriculado(Matricula matricula)
        {
            var existe = await _repositorio.BuscarTodosPorFiltroAsync(
                u => u.TurmaId == matricula.TurmaId && u.AlunoId == matricula.AlunoId
            );

            if (existe.Any())
                throw new RegraNegocioException("O aluno já está matriculado nesta turma.");
        }

    }
}
