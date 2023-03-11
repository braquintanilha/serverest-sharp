# ServeRest Sharp

Olá, seja bem-vindo!! Esse é um projeto estudos de testes de API em .NET 6 com C#, NUnit e RestSharp para o simulador de loja virtual ServeRest API. Para acessar a documentação do ServeRest basta acessar https://serverest.dev/

## Pré-requisitos

Para executar esse projeto é necessário o [.NET 6](https://dotnet.microsoft.com/en-us/download/dotnet/6.0) (Runtime ou SDK). 

## Execução dos testes

Com o projeto já clonado e o .NET instalado corretamente no seu ambiente, basta executar os seguintes comandos na __raíz do projeto__:

`dotnet test` - executa todos os testes;

`dotnet test --filter TestCategory=Login` - executa todos os testes/fixtures que possuam a categoria "Login", por exemplo.

`dotnet test --logger "html;logfilename=report.html"` - executa todos os testes e gera o arquivo de report .html no diretório "TestResults"

`dotnet test --filter TestCategory=Login --logger "html;logfilename=report.html"` - executa os testes filtando pela categoria e gera o report

## W.I.P.

Este projeto ainda está em desenvolvimento, e os próximos passos são:

- ~~Criar o workflow no GitHub Actions para execução dos testes em pipeline de CI~~
- ~~Desenvolver testes dos endpoints de Usuários~~
- Desenvolver testes dos endpoints de Produtos

___

Se você tem alguma dúvida ou sugestão, entre em contato! Vamos bater um papo e tomar um café ☕

Feito com 💜 por Bruno Quintanilha.
