O projeto foi desenvolvido utilizando .Net Core, Asp.Net MVC, C#, AngularJS 1.6, JQuery, SQL Server, EntityFramework Core Code First e o IDE Visual Studio 2017.

Al�m disto utilizei alguns patterns (Inje��o de dependencia, Factory, Repository, Singleton) e conceitos DDD de desenvolvimento e com o c�digo o mais limpo poss�vel.

- Fa�a um rebuild na solution;

- Se precisar mudar a string de conex�o, a mesma est� no projeto TalentManagement.Infrastructure, na classe TalentManagementContext, no m�todo OnConfiguring e tamb�m no projeto do TalentManagement.Api e modificar a string de conex�o no appsetting.json;

- Para criar o banco de dados, clique com o bot�o direito do mouse no projeto TalentManagement.Infrastructure e selecione a op��o "Set as StartUp Project";

- No Package Manager Console, no default project, selecione o projeto TalentManagement.Infrastructure e rode os comandos:
  - Add-Migration NomeDeSuaEscolha;
  - Se o comando acima n�o der certo, rode o comando: Remove-Migration -Force e rode novamente o comando acima;
  - Depois rode o comando Update-Database;
  - Verifique se o banco de dados TalentManagement foi criado com as tabelas correspondente as entidades que est�o no projeto TalentManagement.Domain no diret�rio "Entities";
  - Rode o script script.sql que est� no mesmo diret�rio deste arquivo para popular as tabelas;

- No projeto TalentManagement.API, tem um arquivo em Properties launchSettings.json, dentro deste arquivo esta configurado para o API rodar no endere�o http://localhost:49697/... Se precisar mudar, altere tamb�m o arquivo do projeto TalentManagement.UI em wwwroot, diret�rio app, todos os .js nas primeiras linhas (var urlApi = "http://localhost:49697/api/";);

- Agora clique com bot�o direito do mouse no projeto TalentManagement.UI e selecione a op��o "Set as StartUp Project";

- Antes de rodar a aplica��o, de um rebuild no projeto TalentManagement.API e depois clique com bot�o direito do mouse no projeto TalentManagement.API e selecione a op��o View > View un Browser e deixe o browser em aberto;

- Ap�s isso, execute a aplica��o com F5;

- Na mesma solution existe um projeto de teste unit�rio com alguns metodos que testam a camada de service.