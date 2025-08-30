using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SecretariaEnsino.App.DTO.DtoRequisicao;
using SecretariaEnsino.App.Interface;
using SecretariaEnsino.Domain.Entidades;


namespace SecretariaEnsino.API.Controller
{
    public class AlunoController : BaseController
    {
        private readonly IAlunoServico _servico;

        public AlunoController(IAlunoServico servico)
        {
            _servico = servico;
        }

        [Authorize]
        [ProducesResponseType(typeof(Aluno), 200)]
        public async Task<ActionResult<Aluno>> Adicionar([FromBody] AlunoRequisicao request)
        {
            return Ok(await _servico.Adicionar(request));
        }
    }
}
