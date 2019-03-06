# Camadas da arquitetura do Projeto

* Core (Projetos: Domain e Application)
  * Domain
    * Enums do sistema inteiro
    * Exceptions personalizadas globais (Que sejam reutilizáveis em vários contextos/outros jogos)
    * Interfaces para entities
    * Value Objects (Classes que representam uma coluna complexa no banco)
    * Lógica Global (Que seja reutilizável em vários contextos/outros jogos)
  * Application
    * Interfaces
    * Modelos
    * Lógica Exclusiva (Que seja reutilizável no jogo todo)
    * Queries
    * Validadores
    * Exceptions personalizadas exclusivas (Que sejam reutilizáveis no jogo todo)
* Infrastructure (Projetos: Persistance e Infrastructure)
  * Persistance
    * DbContext(s)
    * Migrations
    * Configurations (De migrations)
    * Seedings (De migrations)
    * Abstrações de banco de dados
  * Infrastructure
    * Tudo que for externo
    * Exemplos
      1. API's
      2. Interações com o FileSystem
      3. Envio de email
      4. Qualquer outra coisa que não possa ser feita com valores estáticos numa classe de testes
* Presentation (Projetos: Tudo relacionado à retornos de dados)
  * Api
    * Apenas lógica de exibição (Como vou retornar esse valor; Json ou Xml; etc...)

# TODOS

* Solução
  * Mover interação com Photon para camada de Infrastructure (?)
  * Definir local para o projeto Server
  * Terminar documentação
* Projetos
  * Core
    * Domain
      1. Definir se existirão planejamentos para projetos futuros
    * Application
      1. Definir interfaces base para o back-end
  * Infrastructure
    * Persistance
      1. Definir banco inicial (SQL x NoSQL)
    * Infrastructure
      1. Validar necessidade de API's externas
      2. Validar relação com o FileSystem
  * Presentation
    * Api
      1. Implementar lógica de login / oauth