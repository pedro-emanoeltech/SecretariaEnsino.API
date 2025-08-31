﻿using AutoMapper;
using FluentValidation;
using SecretariaEnsino.App.DTO.DtoRequisicao;
using SecretariaEnsino.App.DTO.DtoRespostas;
using SecretariaEnsino.App.Interface;
using SecretariaEnsino.Infra.Interface;
using System.Text.RegularExpressions;

namespace SecretariaEnsino.App.Servico
{
    public class AutenticacaoServico : IAutenticacaoServico
    {
        private readonly IMapper _mapper;
        private readonly IUsuarioRepositorio _repositorio;
        private readonly IJwtHandlerServico _jwtHandlerServico;
        private readonly IValidator<LoginRequisicao> _validatorLogin;
        private readonly string _mensagemPadraoLoginInvalido = "Email e/ou senha inválidos";

        public AutenticacaoServico(
            IMapper mapper,
            IUsuarioRepositorio repositorio,
            IJwtHandlerServico jwtHandlerServico,
            IValidator<LoginRequisicao> validator)
        {
            _mapper = mapper;
            _repositorio = repositorio;
            _validatorLogin = validator;
            _jwtHandlerServico = jwtHandlerServico;
        }

        public async Task<LoginResposta> Login(LoginRequisicao loginRequisicao)
        {
            var validationResult = _validatorLogin.Validate(loginRequisicao);
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.ToString());

            if (!EmailValido(loginRequisicao.Email))
                throw new UnauthorizedAccessException(_mensagemPadraoLoginInvalido);


            var usuario = await _repositorio.ObterUsuarioPorEmailAsync(loginRequisicao.Email)
                                ?? throw new UnauthorizedAccessException(_mensagemPadraoLoginInvalido);

            if (!BC.Verify(loginRequisicao.Senha, usuario.Senha))
                throw new UnauthorizedAccessException(_mensagemPadraoLoginInvalido);

            var token = await _jwtHandlerServico.GerarTokenAcessoAsync(usuario);

            return _mapper.Map<LoginResposta>(token);
        }

        private bool EmailValido(string email)
        {
            string emailPattern = @"^\b[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Z|a-z]{2,}\b$";
            return Regex.IsMatch(email!, emailPattern);
        }
 
    }
}
