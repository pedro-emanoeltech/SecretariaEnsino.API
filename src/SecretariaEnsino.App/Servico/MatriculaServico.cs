using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using SecretariaEnsino.App.DTO.DtoRequisicao;
using SecretariaEnsino.App.DTO.DtoRespostas;
using SecretariaEnsino.App.Interface;
using SecretariaEnsino.Domain.Abastacao;
using SecretariaEnsino.Domain.Entidades;
using SecretariaEnsino.Infra.Interface;
using SecretariaEnsino.Infra.Servico;
using System.ComponentModel.DataAnnotations;

namespace SecretariaEnsino.App.Servico
{
    public class MatriculaServico : BaseServico<Matricula, MatriculaRequisicao, MatriculaResposta>, IMatriculaServico
    {
        private readonly IMatriculaRepositorio _repositorio;
        private readonly ITurmaRepositorio _turmaRepositorio;
        private readonly IAlunoRepositorio _alunoRepositorio;

        public MatriculaServico(
            IMapper mapper,
            IMatriculaRepositorio repositorio,
            IValidator<MatriculaRequisicao> validator,
            ITurmaRepositorio turmaRepositorio,
            IAlunoRepositorio alunoRepositorio)
            : base(repositorio, mapper, validator)
        {
            _repositorio = repositorio;
            _turmaRepositorio = turmaRepositorio;
            _alunoRepositorio = alunoRepositorio;
        }

        public override async Task AntesDeAdicionarAsync(Matricula matricula)
        {
            await ValidarAlunoExisteAsync(matricula.AlunoId);
            await ValidarTurmaExisteAsync(matricula.TurmaId);


            await ValidarAlunoJaMatriculado(matricula);
            await ValidarExcedeCapacidadeTurma(matricula);
        }

        private async Task ValidarAlunoExisteAsync(Guid alunoId)
        {
            var aluno = _alunoRepositorio.BuscarPorId(alunoId).FirstOrDefault();
            if (aluno == null)
                throw new RegraNegocioException("O aluno informado não existe.");
        }

        private async Task ValidarTurmaExisteAsync(Guid turmaId)
        {
            var turma = _turmaRepositorio.BuscarPorId(turmaId).FirstOrDefault();
            if (turma == null)
                throw new RegraNegocioException("A turma informada não existe.");


        }

        private async Task ValidarAlunoJaMatriculado(Matricula matricula)
        {
            var existe = await _repositorio.BuscarTodosPorFiltroAsync(
                m => m.TurmaId == matricula.TurmaId && m.AlunoId == matricula.AlunoId
            );

            if (existe.Any())
                throw new RegraNegocioException("O aluno já está matriculado nesta turma.");
        }

        private async Task ValidarExcedeCapacidadeTurma(Matricula matricula)
        {
            var turma = _turmaRepositorio.BuscarPorId(matricula.TurmaId)
                .Include(x => x.Matriculas)
                .FirstOrDefault();

            int totalPrevisto = turma.Matriculas.Count + 1;

            if (totalPrevisto > turma.Capacidade)
                throw new RegraNegocioException("Adicionar este aluno excederia a capacidade máxima da turma.");
        }

    }
}
