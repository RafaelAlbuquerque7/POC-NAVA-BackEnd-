# BackEnd POC-NAVA

Este é o backend do projeto POC-NAVA, desenvolvido em .NET Core com PostgreSQL como banco de dados. Ele é responsável por gerenciar os dados e fornecer APIs consumidas pelo frontend.

---

## Requisitos

Antes de rodar este projeto, certifique-se de ter instalado:

- **.NET Core SDK** (versão 6.0 ou superior)
- **PostgreSQL** (versão 13 ou superior)
- **Frontend do POC-NAVA** (o backend depende do frontend para a interface de usuário)

---

## Configuração do Banco de Dados

1. Configure o banco de dados PostgreSQL:
   - Crie um banco de dados chamado `poc_nava` no PostgreSQL.
   - Altere a string de conexão no arquivo `appsettings.json` com suas credenciais do PostgreSQL:
     ```json
     "ConnectionStrings": {
       "DefaultConnection": "Host=localhost;Database=poc_nava;Username=seu_usuario;Password=sua_senha"
     }
     ```

2. Gere o banco de dados usando as migrações incluídas:

   dotnet ef database update

3. Como Rodar o Projeto

No diretório do backend, instale as dependências:

dotnet restore

4. Execute o projeto:

dotnet run

## Integração com o Frontend ##

Certifique-se de que o frontend do POC-NAVA esteja configurado e rodando.
O frontend consumirá as APIs deste backend, portanto, ambos os projetos precisam estar ativos ao mesmo tempo.