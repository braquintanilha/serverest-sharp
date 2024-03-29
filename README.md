# ServeRest Sharp

![Workflow Tests](https://github.com/braquintanilha/serverest-sharp/actions/workflows/workflow.yml/badge.svg)

Olá, seja bem-vindo!! Esse é um projeto estudos de testes de API em __.NET 7 com C#, NUnit e RestSharp__ para o simulador de loja virtual ServeRest API. 

Documentação do ServeRest: https://serverest.dev/

## Pré-requisitos

Para executar esse projeto é necessário o [.NET 7](https://dotnet.microsoft.com/en-us/download/dotnet/7.0) (Runtime ou SDK).

Todas as dependências estão listadas no arquivo `ServeRestSharp.csproj`. Dessa forma, basta executar os comandos listados abaixo que o build é realizado e as dependências são instaladas automaticamente através do gerenciador de pacotes **NuGet**.

## Execução dos testes

Com o projeto já clonado e o .NET instalado corretamente no seu ambiente, basta executar os seguintes comandos na __raíz do projeto__:

`dotnet test` - executa todos os testes;

`dotnet test --filter TestCategory=Login` - executa todos os testes/fixtures que possuam a categoria "Login", por exemplo.

`dotnet test --logger "html;logfilename=report.html"` - executa todos os testes e gera o arquivo de report .html no diretório "TestResults"

`dotnet test --filter TestCategory=Login --logger "html;logfilename=report.html"` - executa os testes filtando pela categoria e gera o report

## GitHub Actions

Esse projeto possui um workflow do GitHub Actions que executa todos os testes à partir dos seguintes triggers:

- Pull request no branch __main__
- Workflow dispatch (trigger manual)
- Schedulle - o workflow é executado diariamente às 8h

Após a execução, o arquivo **report.html** (test logger) é disponibilizado no __summary__ do workflow.

___

Se você tem alguma dúvida ou sugestão, entre em contato! Vamos tomar um café ☕

Feito com 💜 por Bruno Quintanilha.
