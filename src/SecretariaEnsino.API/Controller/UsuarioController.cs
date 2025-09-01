using Microsoft.AspNetCore.Mvc;
using SecretariaEnsino.App.DTO.DtoRequisicao;
using SecretariaEnsino.App.DTO.DtoRespostas;
using SecretariaEnsino.App.Interface;
using SecretariaEnsino.Domain.Entidades;


namespace SecretariaEnsino.API.Controller
{
    public class UsuarioController : BaseCRUDController<Usuario, UsuarioRequisicao, UsuarioResposta>
    {
        private readonly IUsuarioServico _servico;
        public UsuarioController(IUsuarioServico servico, ILogger<UsuarioController> logger) : base(servico, logger)
        {
            _servico = servico;
        }

        #region CRUD

        /// <summary>
        /// Adiciona um novo usuário do tipo **Administrador** ou **Professor**.
        /// </summary>
        /// <remarks>
        /// **Observações importantes:**
        /// - O tipo de usuário é um **enum** (`TipoUsuario`) que define os perfis do sistema.
        /// - Essa rota **não permite** criar usuários do tipo `Aluno`. Usuários Aluno devem ser criados via rota de cadastro específica.
        /// 
        /// **Enum TipoUsuario:**
        /// - `Administrador` → Usuário com permissão total no sistema.
        /// - `Professor` → Usuário com permissão de professor.
        /// - `Aluno` → Não permitido nesta rota.
        /// 
        /// **Exemplo de requisição:**
        /// ```json
        /// {
        ///   "nome": "Pedro Emanoel",
        ///   "email": "Pedrao.emanoel@exemplo.com",
        ///   "senha": "SenhaForte@123",
        ///   "ativo": true,
        ///   "tipo": "Administrador"
        /// }
        /// ```
        /// **Descrição dos campos:**
        /// - `nome` → Nome completo (mínimo 3 caracteres).
        /// - `email` → Email válido.
        /// - `senha` → Senha forte (mínimo 8 caracteres, com letras maiúsculas, minúsculas, número e símbolo especial).
        /// - `ativo` → Indica se o usuario está ativo no sistema.
        /// </remarks>
        /// <param name="usuarioRequisicao">body contendo os dados do usuário a ser criado.</param>
        /// <returns>Retorna o usuário criado, com todas as propriedades preenchidas.</returns>
        /// <response code="201">Usuário criado com sucesso.</response>
        /// <response code="400">Modelo de dados inválido ou tipo de usuário não permitido.</response>
        /// <response code="500">Erro interno ao processar a solicitação.</response>
        [HttpPost]
        public override async Task<ActionResult<UsuarioResposta>> Adicionar([FromBody] UsuarioRequisicao usuarioRequisicao)
        {
            try
            {
                return await _servico.AdicionarUsuarioAsync(usuarioRequisicao);
            }
            catch (Exception ex)
            {
                return ValidaException(ex);
            }

        }

        /// <summary>
        /// Busca um usuário pelo seu Id.
        /// </summary>
        /// <param name="id">Id do usuário.</param>
        /// <returns>Retorna o usuário encontrado.</returns>
        /// <response code="200">Usuário encontrado.</response>
        /// <response code="400">Id inválido.</response>
        /// <response code="404">Usuário não encontrado.</response>
        /// <response code="500">Erro interno ao processar a solicitação.</response>
        [HttpGet("{id}", Name = "BuscarUsuario")]
        public override async Task<ActionResult<UsuarioResposta>> BuscarPorId(string id)
        {
            return await base.BuscarPorId(id);
        }

        /// <summary>
        /// Atualiza um usuário existente.
        /// </summary>
        /// <param name="id">Id do usuário a ser atualizado.</param>
        /// <param name="requisicao">Objeto contendo os novos dados do usuário.</param>
        /// <returns>Retorna o usuário atualizado.</returns>
        /// <response code="200">Usuário atualizado com sucesso.</response>
        /// <response code="400">Modelo de dados inválido.</response>
        /// <response code="404">Usuário não encontrado.</response>
        /// <response code="500">Erro interno ao processar a solicitação.</response>
        [HttpPut("{id}")]
        public override async Task<ActionResult<UsuarioResposta>> Atualizar(string id, [FromBody] UsuarioRequisicao requisicao)
        {
            return await base.Atualizar(id, requisicao);
        }

        /// <summary>
        /// Deleta um usuário pelo seu Id.
        /// </summary>
        /// <param name="id">Id do usuário a ser deletado.</param>
        /// <returns>Retorna status 204 caso o usuário seja deletado com sucesso.</returns>
        /// <response code="204">Usuário deletado com sucesso.</response>
        /// <response code="400">Id inválido.</response>
        /// <response code="404">Usuário não encontrado.</response>
        /// <response code="500">Erro interno ao processar a solicitação.</response>
        [HttpDelete("{id}")]
        public override async Task<ActionResult> Deletar(string id)
        {
            return await base.Deletar(id);
        }

        #endregion

    }
}
