O projeto foi desenvolvido utilizando .Net Core, Asp.Net MVC, C#, AngularJS 1.6, JQuery, SQL Server, EntityFramework Core Code First e o IDE Visual Studio 2017.

Além disto utilizei alguns patterns (Injeção de dependencia, Factory, Repository, Singleton) e conceitos DDD de desenvolvimento e com o código o mais limpo possível.

- Faça um rebuild na solution;

- Se precisar mudar a string de conexão, a mesma está no projeto TalentManagement.Infrastructure, na classe TalentManagementContext, no método OnConfiguring e também no projeto do TalentManagement.Api e modificar a string de conexão no appsetting.json;

- Para criar o banco de dados, clique com o botão direito do mouse no projeto TalentManagement.Infrastructure e selecione a opção "Set as StartUp Project";

- No Package Manager Console, no default project, selecione o projeto TalentManagement.Infrastructure e rode os comandos:
  - Add-Migration NomeDeSuaEscolha;
  - Se o comando acima não der certo, rode o comando: Remove-Migration -Force e rode novamente o comando acima;
  - Depois rode o comando Update-Database;
  - Verifique se o banco de dados TalentManagement foi criado com as tabelas correspondente as entidades que estão no projeto TalentManagement.Domain no diretório "Entities";
  - Rode o script script.sql que está no mesmo diretório deste arquivo para popular as tabelas;

- No projeto TalentManagement.API, tem um arquivo em Properties launchSettings.json, dentro deste arquivo esta configurado para o API rodar no endereço http://localhost:49697/... Se precisar mudar, altere também o arquivo do projeto TalentManagement.UI em wwwroot, diretório app, todos os .js nas primeiras linhas (var urlApi = "http://localhost:49697/api/";);

- Agora clique com botão direito do mouse no projeto TalentManagement.UI e selecione a opção "Set as StartUp Project";

- Antes de rodar a aplicação, de um rebuild no projeto TalentManagement.API e depois clique com botão direito do mouse no projeto TalentManagement.API e selecione a opção View > View un Browser e deixe o browser em aberto;

- Após isso, execute a aplicação com F5;

- Na mesma solution existe um projeto de teste unitário com alguns metodos que testam a camada de service.