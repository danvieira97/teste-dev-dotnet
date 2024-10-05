# Teste Prático - Dev .NET - Leanwork Group

## Tecnologias
Na raiz do projeto, existem duas pastas: Frontend e LeanWorkAPI.
- O frontend foi desenvolvido com HTML, Javascript e Bootstrap.
- O backend foi desenvolvido com ASP.NET

## Executar Projeto
- O frontend basta instalar a extensao Go Live no VSCode para executar, como não está utlizando nenhum framework, basta rodar a extensão.
- Para executar o backend, é necessário acessar a pasta *LeanWorkAPI* que está dentro da *src* e executar o comando: *`dotnet run Program.cs`*

  

# Banco de dados - SQL Server

## Docker
- Dentro da pasta *LeanWorkAPI* existe uma pasta chamada SQL, que contem um arquivo chamado scripts.js
Nesse arquivo contem toda a instrução para executar o banco de dados.
- Caso tenha um SQL Server instalado no Windows, existe uma ConnectionStrings dentro do arquivo appsettings.json, para rodar o banco. Basta alterar as variaveis de ambiente.

### Após executar o Banco de Dados e o Proejto
É possível acessar a página do swagger do projeto em: http://localhost:5160/swagger/index.html
