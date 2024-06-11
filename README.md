# Dev Back End .NET JR - Documento de Requisitos

## Introdução
Este documento descreve os requisitos de negócio e técnicos para o teste prático destinado a programadores .NET Júnior que desejam ingressar na Leanwork Group como desenvolvedores de aplicações Web focadas em Ecommerce. O teste consiste na criação de uma API para gerenciamento de carrinho de compras, utilizando ASP.NET e banco de dados SQL Server, com acesso aos dados feito exclusivamente via Dapper.

## Objetivos
O objetivo deste teste é avaliar a capacidade do candidato em:
- Desenvolver uma API utilizando o framework web ASP.NET.
- Implementar endpoints para gestão de um carrinho de compras.
- Manipular dados utilizando Dapper com SQL Server.
- Aplicar boas práticas de desenvolvimento, incluindo organização de código, clareza e eficiência.

## Requisitos de Negócio

### Endpoints da API
1. **Obter Carrinho**
   - **Método HTTP**: GET
   - **URL**: `/api/carrinho`
   - **Descrição**: Retorna todos os itens do carrinho.
   - **Resposta**:
     ```json
     {
       "itens": [
         {
           "id": 1,
           "nomeProduto": "Produto A",
           "quantidade": 2,
           "precoUnitario": 50.00,
           "precoTotal": 100.00
         },
         ...
       ],
       "totalItens": 5,
       "valorTotal": 250.00
     }
     ```

2. **Adicionar Item**
   - **Método HTTP**: POST
   - **URL**: `/api/carrinho`
   - **Descrição**: Adiciona um novo item ao carrinho.
   - **Corpo da Requisição**:
     ```json
     {
       "nomeProduto": "Produto B",
       "quantidade": 1,
       "precoUnitario": 30.00
     }
     ```
   - **Resposta**: 
     ```json
     {
       "mensagem": "Item adicionado com sucesso",
       "item": {
         "id": 2,
         "nomeProduto": "Produto B",
         "quantidade": 1,
         "precoUnitario": 30.00,
         "precoTotal": 30.00
       }
     }
     ```

3. **Remover Item**
   - **Método HTTP**: DELETE
   - **URL**: `/api/carrinho/{id}`
   - **Descrição**: Remove um item do carrinho pelo ID.
   - **Resposta**:
     ```json
     {
       "mensagem": "Item removido com sucesso"
     }
     ```

4. **Atualizar Quantidade de Item**
   - **Método HTTP**: PUT
   - **URL**: `/api/carrinho/{id}`
   - **Descrição**: Atualiza a quantidade de um item no carrinho.
   - **Corpo da Requisição**:
     ```json
     {
       "quantidade": 3
     }
     ```
   - **Resposta**:
     ```json
     {
       "mensagem": "Quantidade atualizada com sucesso",
       "item": {
         "id": 1,
         "nomeProduto": "Produto A",
         "quantidade": 3,
         "precoUnitario": 50.00,
         "precoTotal": 150.00
       }
     }
     ```

## Requisitos Técnicos

### Backend
- **ASP.NET**: O desenvolvimento deve ser realizado utilizando o framework web da Microsoft.
- **Banco de Dados**: SQL Server deve ser utilizado para armazenamento dos dados do carrinho.
  - **Dapper**: Deve ser utilizado para acesso aos dados, garantindo manipulação direta do SQL.
- **Modelo de Dados**:
   - **Produto**
     - Id (int)
     - Nome (string)
     - PreçoUnitario (decimal)
   - **ItemCarrinho**
     - Id (int)
     - ProdutoId (int, foreign key)
     - NomeProduto (string)
     - Quantidade (int)
     - PreçoUnitario (decimal)
     - PreçoTotal (decimal, calculado como Quantidade * PreçoUnitario)

### Funcionalidades Específicas
1. **Gerenciamento do Carrinho**:
   - Adicionar itens ao carrinho
   - Remover itens do carrinho
   - Atualizar quantidades de itens no carrinho
2. **Persistência de Dados**: Os dados do carrinho devem ser persistidos no banco de dados SQL Server.

### Estrutura de Tabelas
Deve ser criado o script das 2 tabelas: Carrinhos e Carrinho_Itens.
Criar uma pasta chamada 'SQL' e armazenar os scripts lá dentro do projeto.

## Resultados Essenciais
- **Funcional**: A API deve estar completamente funcional, permitindo a gestão de um carrinho de compras através dos endpoints especificados.
- **Validações**: Deve ser realizado todas validações necessários desde a obrigatoriedade das informações ao adicionar um item ao carrinho, excluir um item que não existe, etc.

## Resultados Desejáveis (Opcional)
- **Desenvolvimento em Camadas**: Implementar a aplicação utilizando uma arquitetura em camadas (camada de apresentação, camada de aplicação, camada de domínio, camada de infraestrutura).
- **Testes**: Implementar testes unitários e/ou de integração para garantir a qualidade do código e a funcionalidade da API.

## Passo a Passo para Realização do Teste

1. **Criar um Fork**
   - Acesse o repositório fornecido no GitHub.
   - Clique no botão "Fork" no canto superior direito da página para criar uma cópia do repositório no seu GitHub.

2. **Clonar o Repositório Fork**
   - Clone o repositório forkado para sua máquina local.
   ```bash
   git clone https://github.com/seu-usuario/nome-do-repositorio.git
   ```
   - Navegue até o diretório do repositório clonado.
   ```bash
   cd nome-do-repositorio
   ```

3. **Criar a Estrutura do Projeto**
   - Crie uma pasta chamada `src` dentro do diretório do repositório clonado.
   ```bash
   mkdir src
   ```

4. **Desenvolver o Projeto**
   - Dentro da pasta `src`, desenvolva a aplicação conforme os requisitos descritos anteriormente.

5. **Subir o Projeto para o Repositório**
   - Adicione todos os arquivos do projeto à área de staging do Git.
   ```bash
   git add .
   ```
   - Faça um commit das alterações.
   ```bash
   git commit -m "Desenvolvimento do projeto do carrinho de compras"
   ```
   - Envie o commit para o repositório remoto.
   ```bash
   git push origin main
   ```

6. **Enviar Notificação de Conclusão**
   - Ao finalizar o desenvolvimento e subir todo o projeto no repositório, envie um email para `testes@leanwork.com.br` com as seguintes informações:
     - Seu nome completo.
     - O link para o repositório do GitHub com o projeto desenvolvido.
     - Qualquer outra informação que julgar relevante.

## Considerações Finais
- Certifique-se de que todos os arquivos necessários para a execução do projeto estão incluídos no repositório.
- Inclua um arquivo `README.md` com instruções detalhadas para configuração do ambiente e execução do projeto.
- Garanta que o código esteja bem organizado e documentado conforme as boas práticas de desenvolvimento.

Boa sorte!















# Documento de Requisitos do Teste Prático para Programadores Júnior

## Introdução
Este documento descreve os requisitos de negócio e técnicos para o teste prático destinado a programadores júnior que desejam ingressar na nossa empresa como desenvolvedores de aplicações Web focadas em Ecommerce. O teste consiste na criação de uma página HTML para um carrinho de compras com funcionalidades específicas, utilizando ASP.NET MVC ou Razor Pages e banco de dados SQL Server.

## Objetivos
O objetivo deste teste é avaliar a capacidade do candidato em:
- Desenvolver uma aplicação web utilizando ASP.NET MVC ou Razor Pages.
- Implementar uma interface de usuário dinâmica com HTML, CSS e JavaScript.
- Manipular dados utilizando Entity Framework ou Dapper com SQL Server.
- Aplicar boas práticas de desenvolvimento, incluindo organização de código, clareza e eficiência.

## Requisitos de Negócio
1. **Página do Carrinho de Compras**: A página deve exibir uma tabela com os seguintes campos para cada item no carrinho:
   - Nome do Produto
   - Quantidade
   - Preço Unitário
   - Preço Total (Quantidade x Preço Unitário)
   - Botão para Excluir Item

2. **Adicionar Item ao Carrinho**: Deve haver um botão "Adicionar Item", que ao ser clicado, exibe um modal com os seguintes campos:
   - Nome do Produto
   - Preço Unitário
   - Quantidade
   - Botão para Adicionar o Produto ao Carrinho

3. **Total de Itens e Valor Total**: Abaixo da tabela do carrinho, deve haver uma área que exibe:
   - Total de Itens (soma das quantidades de todos os produtos)
   - Valor Total (soma de todos os preços totais dos produtos)

## Requisitos Técnicos

### Frontend
- **HTML/CSS**: A interface deve ser desenvolvida utilizando HTML5 e CSS3, garantindo compatibilidade com os principais navegadores.
- **JavaScript**: Deve ser utilizado para manipulação do DOM, exibição de modais e atualização dinâmica dos totais de itens e valores.
- **Bootstrap** (opcional): Pode ser utilizado para estilização e componentes de UI, como modais.

### Backend
- **ASP.NET MVC ou Razor Pages**: O desenvolvimento deve ser realizado utilizando uma dessas tecnologias.
- **Banco de Dados**: SQL Server deve ser utilizado para armazenamento dos dados do carrinho.
  - **Entity Framework ou Dapper**: Pode ser utilizado qualquer um dos dois para acesso aos dados.
- **Modelo de Dados**:
  - **Produto**: Representa os produtos disponíveis para adicionar ao carrinho.
  - **ItemCarrinho**: Representa os itens no carrinho de compras.

### Funcionalidades Específicas
1. **CRUD de Produtos**: Deve ser possível criar, ler, atualizar e excluir produtos.
2. **Gerenciamento do Carrinho**:
   - Adicionar itens ao carrinho
   - Remover itens do carrinho
   - Atualizar quantidades de itens no carrinho
3. **Persistência de Dados**: Os dados do carrinho devem ser persistidos no banco de dados SQL Server.

## Detalhes de Implementação

### Modelo de Dados
- **Produto**
  - Id (int)
  - Nome (string)
  - PreçoUnitario (decimal)
- **ItemCarrinho**
  - Id (int)
  - ProdutoId (int, foreign key)
  - NomeProduto (string)
  - Quantidade (int)
  - PreçoUnitario (decimal)
  - PreçoTotal (decimal, calculado como Quantidade * PreçoUnitario)

## Requisitos Não Funcionais
- **Performance**: A aplicação deve carregar e responder de forma rápida às interações do usuário.
- **Segurança**: Validação adequada dos dados de entrada para prevenir ataques como SQL Injection e XSS.
- **Usabilidade**: A interface deve ser intuitiva e fácil de usar.

## Considerações Finais
Os candidatos devem entregar o código-fonte completo do projeto, juntamente com um README contendo instruções para configuração do ambiente, execução do projeto e qualquer outro detalhe relevante. 

Este teste prático permitirá avaliar a habilidade do candidato em desenvolver uma aplicação web funcional e eficiente, abordando aspectos chave do desenvolvimento de ecommerce.
