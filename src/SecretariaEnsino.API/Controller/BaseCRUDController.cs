﻿using Microsoft.AspNetCore.Mvc;
using SecretariaEnsino.App.Interface;
using SecretariaEnsino.Domain.Abastacao;
using Swashbuckle.AspNetCore.Annotations;

namespace SecretariaEnsino.API.Controller
{
    public abstract class BaseCRUDController<TEntidade, TDtoRequisicao, TDtoResposta> : BaseController
       where TEntidade : BaseEntidade, IEntidade
       where TDtoRequisicao : IBaseDto
       where TDtoResposta : IBaseDto
    {

        private readonly IBaseService<TEntidade, TDtoRequisicao, TDtoResposta> _servico;

        public BaseCRUDController(IBaseService<TEntidade, TDtoRequisicao, TDtoResposta> servico, ILogger logger) : base(logger)
        {
            _servico = servico;
        }


        [HttpPost]
        [SwaggerResponse(StatusCodes.Status200OK, "Operação realizada com sucesso.")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Modelo de dados inválido.")]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "Falha na autenticação.")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro interno ao processar a solicitação.")]
        public virtual async Task<ActionResult<TDtoResposta>> Adicionar([FromBody] TDtoRequisicao requisicao)
        {
            if (requisicao == null)
                return BadRequest("Conteúdo não pode ser nulo");

            try
            {
                var resposta = await _servico.AdicionarAsync(requisicao);
                return Ok(resposta);
            }
            catch (Exception ex)
            {
                return ValidaException(ex);
            }
        }


        [HttpPut("{id}", Name = "Atualizar[Controller]")]
        [SwaggerResponse(StatusCodes.Status200OK, "Registro atualizado com sucesso.")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Id inválido ou conteúdo inválido.")]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "Falha na autenticação.")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Registro não encontrado.")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro interno ao processar a solicitação.")]
        public virtual async Task<ActionResult<TDtoResposta>> Atualizar(string id, [FromBody] TDtoRequisicao requisicao)
        {

            if (!TryParseGuid(id, out Guid guidId))
                return BadRequest("Id inválido ou nulo.");

            if (requisicao == null)
                return BadRequest("Conteúdo não pode ser nulo");

            try
            {
                var resposta = await _servico.AtualizarAsync(guidId, requisicao);
                if (resposta == null)
                    return NotFound("Registro não encontrado");

                return Ok(resposta);
            }
            catch (Exception ex)
            {
                return ValidaException(ex);
            }
        }


        [HttpGet("{id}", Name = "Buscar[Controller]")]
        [SwaggerResponse(StatusCodes.Status200OK, "Registro encontrado com sucesso.")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Id inválido ou requisição mal formada.")]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "Falha na autenticação.")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Registro não encontrado.")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro interno ao processar a solicitação.")]
        public virtual async Task<ActionResult<TDtoResposta>> BuscarPorId(string id)
        {
            if (!TryParseGuid(id, out Guid guidId))
                return BadRequest("Id inválido ou nulo.");

            try
            {
                var resposta = await _servico.BuscarPorIdAsync(guidId);
                if (resposta == null)
                    return NotFound("Registro não encontrado");

                return Ok(resposta);
            }
            catch (Exception ex)
            {
                return ValidaException(ex);
            }
        }

        [HttpDelete("{id}", Name = "Deletar[Controller]")]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Registro deletado com sucesso.")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Id inválido.")]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "Falha na autenticação.")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro interno ao processar a solicitação.")]
        public virtual async Task<ActionResult> Deletar(string id)
        {
            if (!TryParseGuid(id, out Guid guidId))
                return BadRequest("Id inválido ou nulo.");
            try
            {
                await _servico.Deletar(guidId);
                return NoContent();
            }
            catch (Exception ex)
            {
                return ValidaException(ex);
            }
        }

        protected bool TryParseGuid(string id, out Guid guidId)
        {
            guidId = Guid.Empty;

            if (string.IsNullOrWhiteSpace(id))
                return false;

            return Guid.TryParse(id, out guidId);
        }


    }

}
