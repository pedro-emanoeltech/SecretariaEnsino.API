using Microsoft.AspNetCore.Mvc;
using SecretariaEnsino.App.DTO;
using SecretariaEnsino.App.DTO.DtoRequisicao;
using SecretariaEnsino.App.DTO.DtoRespostas;
using SecretariaEnsino.App.Filtro;
using SecretariaEnsino.App.Interface;
using SecretariaEnsino.Domain.Entidades;


namespace SecretariaEnsino.API.Controller
{
    public class AlunoController : BaseCRUDController<Aluno, AlunoRequisicao, AlunoResposta>
    {
        private readonly IAlunoServico _servico;
        public AlunoController(IAlunoServico servico, ILogger<AlunoController> logger) : base(servico, logger)
        {
            _servico = servico;
        }

        #region CRUD

        /// <summary>
        /// Adiciona um novo **aluno** ao sistema.
        /// </summary>
        /// <remarks>
        /// **Observações importantes:**
        /// - Essa rota é específica para criação de alunos.
        /// - O aluno será registrado com perfil de **Aluno** automaticamente.
        ///
        /// **Exemplo de requisição:**
        /// ```json
        /// {
        ///   "nome": "Maria Souza",
        ///   "email": "maria.souza@exemplo.com",
        ///   "senha": "SenhaForte@123",
        ///   "ativo": true,
        ///   "dataNascimento": "2005-06-15",
        ///   "cpf": "12345678901"
        /// }
        /// ```
        /// 
        /// **Descrição dos campos:**
        /// - `nome` → Nome completo do aluno (mínimo 3 caracteres).
        /// - `email` → Email válido do aluno.
        /// - `senha` → Senha forte (mínimo 8 caracteres, com letras maiúsculas, minúsculas, número e símbolo especial).
        /// - `ativo` → Indica se o aluno está ativo no sistema.
        /// - `dataNascimento` → Data de nascimento do aluno.
        /// - `cpf` → CPF do aluno (11 dígitos numéricos).
        /// </remarks>
        /// <param name="alunoRequisicao">Objeto contendo os dados do aluno a ser criado.</param>
        /// <returns>Retorna o aluno criado, com todas as propriedades preenchidas.</returns>
        /// <response code="201">Aluno criado com sucesso.</response>
        /// <response code="400">Modelo de dados inválido ou campos obrigatórios ausentes.</response>
        /// <response code="500">Erro interno ao processar a solicitação.</response>
        [HttpPost]
        public override async Task<ActionResult<AlunoResposta>> Adicionar([FromBody] AlunoRequisicao alunoRequisicao)
        {
            return await base.Adicionar(alunoRequisicao);
        }

        /// <summary>
        /// Busca um aluno pelo seu Id.
        /// </summary>
        /// <param name="id">Id do aluno.</param>
        /// <returns>Retorna o aluno encontrado.</returns>
        /// <response code="200">Aluno encontrado.</response>
        /// <response code="400">Id inválido.</response>
        /// <response code="404">Aluno não encontrado.</response>
        /// <response code="500">Erro interno ao processar a solicitação.</response>
        [HttpGet("{id}", Name = "BuscarAluno")]
        public override async Task<ActionResult<AlunoResposta>> BuscarPorId(string id)
        {
            return await base.BuscarPorId(id);
        }

        /// <summary>
        /// Atualiza um aluno existente.
        /// </summary>
        /// <param name="id">Id do aluno a ser atualizado.</param>
        /// <param name="requisicao">Body contendo os novos dados do aluno.</param>
        /// <returns>Retorna o aluno atualizado.</returns>
        /// <response code="200">Aluno atualizado com sucesso.</response>
        /// <response code="400">Modelo de dados inválido.</response>
        /// <response code="404">Aluno não encontrado.</response>
        /// <response code="500">Erro interno ao processar a solicitação.</response>
        [HttpPut("{id}")]
        public override async Task<ActionResult<AlunoResposta>> Atualizar(string id, [FromBody] AlunoRequisicao requisicao)
        {
            return await base.Atualizar(id, requisicao);
        }

        /// <summary>
        /// Deleta um aluno pelo seu Id.
        /// </summary>
        /// <param name="id">Id do aluno a ser deletado.</param>
        /// <returns>Retorna status 204 caso o aluno seja deletado com sucesso.</returns>
        /// <response code="204">Aluno deletado com sucesso.</response>
        /// <response code="400">Id inválido.</response>
        /// <response code="404">Aluno não encontrado.</response>
        /// <response code="500">Erro interno ao processar a solicitação.</response>
        [HttpDelete("{id}")]
        public override async Task<ActionResult> Deletar(string id)
        {
            return await base.Deletar(id);
        }

        /// <summary>
        /// Busca todos os alunos aplicando filtros opcionais.
        /// </summary>
        /// <param name="filtro">Parâmetros opcionais para filtrar os alunos (ex: Nome, CPF, Data de Nascimento).</param>
        /// <returns>Uma lista de alunos encontrados conforme o filtro informado.</returns>
        /// <response code="200">Lista de alunos retornada com sucesso.</response>
        /// <response code="400">Filtro inválido ou mal formatado.</response>
        /// <response code="404">Nenhum aluno encontrado com os critérios informados.</response>
        /// <response code="500">Erro interno ao processar a solicitação.</response>
        [HttpGet(Name = "BuscarTodosAlunos")]
        public async Task<ActionResult<ResultadoPaginado<AlunoResposta>>> BuscarTodosAlunos([FromQuery] AlunoDtoFiltro filtro)
        {
            try
            {
                var filtroBuilder = new AlunoFiltroBuilder(filtro);
                var query = await _servico.BuscarPorFiltro<AlunoFiltroBuilder>(filtroBuilder);
                var resultado = await ResultadoPaginado<AlunoResposta>.CriarAsync(query, filtro);

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
