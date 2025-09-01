using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SecretariaEnsino.App.DTO;
using SecretariaEnsino.App.DTO.DtoRequisicao;
using SecretariaEnsino.App.DTO.DtoRespostas;
using SecretariaEnsino.App.Filtro;
using SecretariaEnsino.App.Interface;
using SecretariaEnsino.Domain.Entidades;
using Swashbuckle.AspNetCore.Annotations;


namespace SecretariaEnsino.API.Controller
{
    public class MatriculaController : BaseCRUDController<Matricula, MatriculaRequisicao, MatriculaResposta>
    {
        private readonly IMatriculaServico _servico;

        public MatriculaController(IMatriculaServico servico, ILogger<MatriculaController> logger)
            : base(servico, logger)
        {
            _servico = servico;
        }

        #region CRUD

        /// <summary>
        /// Cria uma nova matrícula de aluno em uma turma.
        /// </summary>
        /// <remarks>
        /// **Regras importantes:**
        /// - Um aluno **não pode ser matriculado duas vezes** na mesma turma.
        /// - A turma deve ter **capacidade disponível**.
        /// - Apenas alunos ativos podem ser matriculados.
        /// - O status da matrícula será definido automaticamente como "Ativa" na criação.
        ///
        /// **Exemplo de requisição:**
        /// ```json
        /// {
        ///   "alunoId": "123e4567-e89b-12d3-a456-426614174000",
        ///   "turmaId": "987e6543-e21b-34d3-a456-426614174999"
        /// }
        /// ```
        /// 
        /// **Descrição dos campos:**
        /// - `alunoId` → Id do aluno que será matriculado (obrigatório, GUID).
        /// - `turmaId` → Id da turma na qual o aluno será matriculado (obrigatório, GUID).
        /// </remarks>
        /// <param name="matriculaRequisicao">body contendo os dados da matrícula a ser criada.</param>
        /// <returns>Retorna a matrícula criada, incluindo status e datas.</returns>
        /// <response code="201">Matrícula criada com sucesso.</response>
        /// <response code="400">Modelo de dados inválido ou regras de negócio violadas (ex.: turma cheia, aluno já matriculado).</response>
        /// <response code="500">Erro interno ao processar a solicitação.</response>
        [HttpPost]
        public override async Task<ActionResult<MatriculaResposta>> Adicionar([FromBody] MatriculaRequisicao matriculaRequisicao)
        {
            return await base.Adicionar(matriculaRequisicao);
        }

        /// <summary>
        /// Busca uma matrícula pelo seu identificador único.
        /// </summary>
        /// <param name="id">Identificador da matrícula.</param>
        /// <returns>Retorna a matrícula encontrada.</returns>
        /// <response code="200">Matrícula encontrada.</response>
        /// <response code="400">Id inválido.</response>
        /// <response code="404">Matrícula não encontrada.</response>
        /// <response code="500">Erro interno ao processar a solicitação.</response>
        [HttpGet("{id}", Name = "BuscarMatricula")]
        public override async Task<ActionResult<MatriculaResposta>> BuscarPorId(string id)
        {
            return await base.BuscarPorId(id);
        }
 
        /// <summary>
        /// Remove uma matrícula pelo seu identificador.
        /// </summary>
        /// <param name="id">Identificador da matrícula a ser deletada.</param>
        /// <returns>Retorna status 204 caso a matrícula seja deletada com sucesso.</returns>
        /// <response code="204">Matrícula deletada com sucesso.</response>
        /// <response code="400">Id inválido.</response>
        /// <response code="404">Matrícula não encontrada.</response>
        /// <response code="500">Erro interno ao processar a solicitação.</response>
        [HttpDelete("{id}")]
        public override async Task<ActionResult> Deletar(string id)
        {
            return await base.Deletar(id);
        }

        /// <summary>
        /// Busca todas as matrículas aplicando filtros opcionais.
        /// </summary>
        /// <param name="filtro">Parâmetros opcionais para filtrar as matrículas (ex: AlunoId, TurmaId, Data da matrícula).</param>
        /// <returns>Uma lista de matrículas encontradas conforme o filtro informado.</returns>
        /// <response code="200">Lista de matrículas retornada com sucesso.</response>
        /// <response code="400">Filtro inválido ou mal formatado.</response>
        /// <response code="404">Nenhuma matrícula encontrada com os critérios informados.</response>
        /// <response code="500">Erro interno ao processar a solicitação.</response>
        [HttpGet(Name = "BuscarTodasMatriculas")]
        public async Task<ActionResult<ResultadoPaginado<MatriculaResposta>>> BuscarTodasMatriculas([FromQuery] MatriculaDtoFiltro filtro)
        {
            try
            {
                var filtroBuilder = new MatriculaFiltroBuilder(filtro);
                var query = await _servico.BuscarPorFiltroAsync<MatriculaFiltroBuilder>(filtroBuilder);
                var resultado = await ResultadoPaginado<MatriculaResposta>.CriarAsync(query, filtro);

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return ValidaException(ex);
            }
        }

        #endregion
    }
}
