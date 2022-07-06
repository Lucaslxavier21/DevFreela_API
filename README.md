# Projeto DevFreela API
## Fluxo do Projeto
- Cadastro, Atualização, Cancelamento e Consultas de serviços de Desenvolvedores Freelancers.

- Cadastro de Usuários, tanto de Devs Freelancers quanto de Clientes. 

- Adicionar comentários

- Pagamentos de Projetos 

- Definir, iniciar e finalizar um projeto


## Tecnologias utilizadas no Projeto;
- Swagger

- Arquitetura Limpa

- Camadas de responsabilidade = Core, Infrastructure, Application e API

- Entitty Framework Core

- Injeção de Dependências 

- Dapper ORM

- CQRS ( Command Query Responsibility Segragation )

- MediatR

- JWT - Json Web Token

- xUnit - ( Para testes Unitários ) 

- Microsserviços e Mensageria com RabbitMQ 

## Camadas de Responsabilidades 

- Core: Contém os serviços de domínio, classes, repositórios, interfaces. As classes usam private set para reforçar as imutabilidades.
Infrastructure: Contém as implementações do repositório e a classe DbContext.
Application: Contém as implementações dos Commands, Queries e Validators, além dos, View Models e Input Models.
API: Contém os Controllers, Injeção de Dependência, Swagger, SQL-Server DbContext
