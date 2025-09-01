# Secretaria de Ensino API

# Secretaria de Ensino API

API desenvolvida representando um sistema interno de **Secretaria de Ensino** para controle de alunos, turmas e matrículas.  

## 🚀 Tecnologias Utilizadas
- **.NET Core 8**
- **SQL Server**
- **Entity Framework Core**
- **AutoMapper**
- **FluentValidation**
- **JWT Authentication**
- **Swagger/OpenAPI**
- **Docker** (opcional para SQL Server)

> ⚠️ Por falta de tempo, **não foram desenvolvidos testes unitários nem a interface web**, pois não seria possível garantir qualidade nesses pontos, em pouco tempo.

---

## Funções Atendidas

| Função                       | Status |
|-------------------------------|--------|
| API                           | ✅     |
| Regras de Negócio             | ✅     |
| Campos adicionais             | ✅     |
| Testes unitários              | ❌     |
| Web                           | ❌     |

---

## Autenticação

Todas as rotas exigem autenticação JWT, exceto as rotas de login e registro inicial de administrador.

- Para iniciar o sistema, será criado um **usuário padrão admin**:
  - **Email:** `admin@exemplo.com`
  - **Senha:** `Admin@123`

> A senha será criptografada ao salvar no banco e verificada ao logar.  

---

## Configuração do banco

Para executar localmente usando Docker:

```bash
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=BlaBla123!" `
   -p 1433:1433 --name sqlserver `
   -d mcr.microsoft.com/mssql/server:2022-latest
 
```

## Configuração da Migrations

Se precisar roda migration utilize:

```bash

dotnet ef migrations add nomeDaMigracao --context SecretariaEnsinoContexto --project ../SecretariaEnsino.Infra --startup-project ../SecretariaEnsino.API

```
## Validações importantes
- Usuário: email único, senha com mínimo de 8 caracteres, letras maiúsculas e minúsculas, número e símbolo.
- Aluno: CPF único, validação de existência antes de matricular.
- Turma: Capacidade mínima 1, datas opcionais mas consistentes (DataInicio < DataFim), professor opcional mas mínimo 3 caracteres se fornecido.
- Matrícula: validação de capacidade e se aluno já está matriculado
  
## Melhorias não implementadas

- Separar senha do cadastro e atualização, pois não é obrigatório enviar senha na atualização.
- Implementar controle granular de permissões por tipo de usuário (ex.: Aluno não pode criar Turma).

## Modelo Criado para Seguir com rascunho.
- Criei um modelo simples com a ferramenta Obsidian para seguir o planejamento do desenvolvimento.

<img width="460" height="642" alt="image" src="https://github.com/user-attachments/assets/14783972-66a4-4da4-8d17-56a2f9e9f275" />
<img width="410" height="608" alt="image" src="https://github.com/user-attachments/assets/c7ed9925-5b50-4fde-b81b-5a316227403e" />

 
