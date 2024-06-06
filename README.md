# 🌐 Ocean | Guarg - Global Solution 2024
 
## Descrição
Este é um projeto que tem como intuito utilizar drones submarinos implantados com inteligência artificial em suas câmeras, capazes de fazer o reconhecimento e o mapeamento do lixo presente em reservas de água (mar, rios e lagoas), disponibilizando em um site estas informações para que terceiros (Governos, ONGs, e voluntários) possam fazer a retirada dos dejetos.
 
## Tecnologias Utilizadas
### .NET 7:
- **Microsoft.AspNetCore.OpenApi (7.0.2)**: Suporte para OpenAPI/Swagger em aplicações ASP.NET Core.
- **Microsoft.EntityFrameworkCore (7.0.0)**: Provedor ORM para Entity Framework Core, facilitando o acesso a dados.
- **Microsoft.EntityFrameworkCore.Tools (7.0.0)**: Ferramentas para desenvolvimento com Entity Framework Core.
- **Oracle.EntityFrameworkCore (7.21.8)**: Provedor Entity Framework Core para Oracle Database.
- **Oracle.ManagedDataAccess.Core (23.4.0)**: Biblioteca de acesso a dados para Oracle Database sem dependências de cliente Oracle.
- **Swashbuckle.AspNetCore (6.6.2)**: Geração de documentação e UI do Swagger para APIs ASP.NET Core.
 
 
### Banco de Dados:
- **Oracle Database**: Utilizado como banco de dados relacional para a aplicação.
 
## Pré-requisitos
-.NET 7.0 SDK
- Git
 
## Como executar
1. Clone este repositório do Github
2. Navegue até o diretório do projeto
3. Execute o comando  para restaurar as dependências `dotnet restore` 
4. Execute o comando para iniciar a aplicação: `dotnet run`
 
## Instruções
Após executar o projeto, a página do Swagger será aberta automaticamente no navegador, geralmente em http://localhost:5000/swagger (ou https://localhost:5001/swagger se estiver usando HTTPS).
 
## Documentação da API
 
### DroneController
 
| Método HTTP | Endpoint          | Descrição                            | Parâmetros                                      |
|-------------|-------------------|--------------------------------------|-------------------------------------------------|
| POST        | `/api/drones`     | Cria um novo drone                   | Corpo da Requisição: `DroneDto`                 |
| GET         | `/api/drones`     | Retorna uma lista paginada de drones | Query Params: `page` (int, default: 0), `size` (int, default: 5) |
| GET         | `/api/drones/{id}`| Retorna os detalhes de um drone específico | Path Variable: `id` (Long)                   |
| PUT         | `/api/drones/{id}`| Atualiza um drone existente          | Path Variable: `id` (Long), Corpo da Requisição: `DroneDto` |
| DELETE      | `/api/drones/{id}`| Deleta um drone específico           | Path Variable: `id` (Long)                      |
 
### GarbageController
 
| Método HTTP | Endpoint                              | Descrição                                         | Parâmetros                                      |
|-------------|---------------------------------------|---------------------------------------------------|-------------------------------------------------|
| POST        | `/api/garbages`                       | Cria um novo registro de lixo                     | Corpo da Requisição: `GarbageDto`               |
| GET         | `/api/garbages`                       | Retorna uma lista de todos os registros de lixo   | Nenhum                                          |
| GET         | `/api/garbages/detections/{droneId}`  | Retorna uma lista paginada de lixos detectados por um drone | Path Variable: `droneId` (Long), Query Params: `page` (int, default: 0), `size` (int, default: 5) |
| GET         | `/api/garbages/{id}`                  | Retorna os detalhes de um registro de lixo específico | Path Variable: `id` (Long)                  |
| PUT         | `/api/garbages/{id}`                  | Atualiza um registro de lixo existente            | Path Variable: `id` (Long), Corpo da Requisição: `GarbageDto` |
| DELETE      | `/api/garbages/{id}`                  | Deleta um registro de lixo específico             | Path Variable: `id` (Long)                      |
