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
    public class TurmaController : BaseCRUDController<Turma, TurmaRequisicao, TurmaResposta>
    {

        private readonly ITurmaServico _servico;

        public TurmaController(ITurmaServico servico, ILogger<TurmaController> logger) : base(servico, logger)
        {
            _servico = servico;
        }

        #region CRUD


        /// <summary>
        /// Cria uma nova turma no sistema.
        /// </summary>
        /// <remarks>
        /// **Regras importantes:**
        /// - O nome da turma deve ter **pelo menos 3 caracteres**.
        /// - Se informado a data de início deve ser anterior à data de fim.
        /// - A capacidade da turma deve ser um valor positivo (mínimo 1).
        /// - O status da turma é definido pelo enum `StatusTurma`:
        ///     - `Aberta` → Turma disponível para matrícula.
        ///     - `EmAndamento` → Turma atualmente em andamento.
        ///     - `Encerrada` → Turma finalizada, sem novas matrículas.
        ///     - `Cancelada` → Turma cancelada, sem matrícula permitida.
        /// - O professor é opcional, mas se informado,deve ter **pelo menos 3 caracteres**.
        ///
        /// **Exemplo de requisição:**
        /// ```json
        /// {
        ///   "nome": "Turma Tecnologia Api",
        ///   "descricao": "Turma para desenvolvimento de apis",
        ///   "dataInicio": "2025-09-01T08:00:00",
        ///   "dataFim": "2025-12-15T17:00:00",
        ///   "capacidade": 30,
        ///   "professor": "Jose prof",
        ///   "status": "Aberta"
        /// }
        /// ```
        /// 
        /// **Descrição dos campos:**
        /// - `nome` → Nome da turma (mínimo 3 caracteres, obrigatório).
        /// - `descricao` → Descrição opcional da turma.
        /// - `dataInicio` → Data de início das aulas.
        /// - `dataFim` → Data de término das aulas.
        /// - `capacidade` → Número máximo de alunos (obrigatório, mínimo 1).
        /// - `professor` → Nome do professor (mínimo 3 caracteres, obrigatório).
        /// - `status` → Status da turma (enum `StatusTurma`), valores possíveis: `Aberta`, `EmAndamento`, `Encerrada`, `Cancelada`.
        /// </remarks>
        /// <param name="turmaRequisicao">body contendo os dados da turma a ser criada.</param>
        /// <returns>Retorna a turma criada, incluindo todas as propriedades e status.</returns>
        /// <response code="201">Turma criada com sucesso.</response>
        /// <response code="400">Modelo de dados inválido ou regras de negócio violadas (ex.: datas inválidas, capacidade negativa).</response>
        /// <response code="500">Erro interno ao processar a solicitação.</response>
        [HttpPost]
        public override async Task<ActionResult<TurmaResposta>> Adicionar([FromBody] TurmaRequisicao turmaRequisicao)
        {
            return await base.Adicionar(turmaRequisicao);
        }

        /// <summary>
        /// Busca uma turma pelo seu Id.
        /// </summary>
        /// <param name="id">Id da turma.</param>
        /// <returns>Retorna a turma encontrada.</returns>
        /// <response code="200">Turma encontrada.</response>
        /// <response code="400">Id inválido.</response>
        /// <response code="404">Turma não encontrada.</response>
        /// <response code="500">Erro interno ao processar a solicitação.</response>
        [HttpGet("{id}", Name = "BuscarTurma")]
        public override async Task<ActionResult<TurmaResposta>> BuscarPorId(string id)
        {
            return await base.BuscarPorId(id);
        }

        /// <summary>
        /// Atualiza os dados de uma turma existente.
        /// </summary>
        /// <param name="id">Id da turma a ser atualizada.</param>
        /// <param name="requisicao">Objeto contendo os novos dados da turma.</param>
        /// <returns>Retorna a turma atualizada.</returns>
        /// <remarks>
        /// **Exemplo de Requisição:**
        /// ```json
        /// {
        ///     "Nome": "Turma B",
        ///     "Descricao": "Descrição da turma B",
        ///     "DataInicio": "2025-09-01",
        ///     "DataFim": "2025-12-20",
        ///     "Capacidade": 30,
        ///     "Professor": "Professor X",
        ///     "Status": 1
        /// }
        /// ```
        /// </remarks>
        /// <response code="200">Turma atualizada com sucesso.</response>
        /// <response code="400">Modelo de dados inválido.</response>
        /// <response code="404">Turma não encontrada.</response>
        /// <response code="500">Erro interno ao processar a solicitação.</response>
        [HttpPut("{id}")]
        public override async Task<ActionResult<TurmaResposta>> Atualizar(string id, [FromBody] TurmaRequisicao requisicao)
        {
            return await base.Atualizar(id, requisicao);
        }

        /// <summary>
        /// Remove uma turma pelo Id.
        /// </summary>
        /// <param name="id">Id da turma a ser deletada.</param>
        /// <returns>Retorna status 204 caso a turma seja deletada com sucesso.</returns>
        /// <response code="204">Turma deletada com sucesso.</response>
        /// <response code="400">Id inválido.</response>
        /// <response code="404">Turma não encontrada.</response>
        /// <response code="500">Erro interno ao processar a solicitação.</response>
        [HttpDelete("{id}")]
        public override async Task<ActionResult> Deletar(string id)
        {
            return await base.Deletar(id);
        }

        /// <summary>
        /// Busca todas as turmas aplicando filtros opcionais.
        /// </summary>
        /// <param name="filtro">Parâmetros opcionais para filtrar as turmas (ex: Descrição, Período, CursoId).</param>
        /// <returns>Uma lista de turmas encontradas conforme o filtro informado.</returns>
        /// <response code="200">Lista de turmas retornada com sucesso.</response>
        /// <response code="400">Filtro inválido ou mal formatado.</response>
        /// <response code="404">Nenhuma turma encontrada com os critérios informados.</response>
        /// <response code="500">Erro interno ao processar a solicitação.</response>
        [HttpGet(Name = "BuscarTodasTurmas")]
        public async Task<ActionResult<ResultadoPaginado<TurmaResposta>>> BuscarTodasTurmas([FromQuery] TurmaDtoFiltro filtro)
        {
            try
            {
                var filtroBuilder = new TurmaFiltroBuilder(filtro);
                var query = await _servico.BuscarPorFiltro<TurmaFiltroBuilder>(filtroBuilder);

                var resultado = await ResultadoPaginado<TurmaResposta>.CriarAsync(query, filtro);

                if (resultado.Items == null || !resultado.Items.Any())
                    return NotFound("Nenhum aluno encontrado.");

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
