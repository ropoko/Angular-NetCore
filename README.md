## About

Made to learn API concepts and its integration with an Angular interface.

### :computer: Technologies
 - [.Net Core 3.1](https://dotnet.microsoft.com/)
 - [Angular 10](https://angular.io/)
 - [MySql](https://www.mysql.com/)
 - [Angular Material](https://material.angular.io/)
 - [NodeJS](https://nodejs.org/en/)

### API 
Made with .Net Core 3.1 with JWT included and Entity FrameworkCore, but the JWT isn't used, just for knowledge and tests.

 The database uses MySql as default, but in API there are some context.cs files for differents types of DB, like Oracle, Sql Server and MySql.

 - [Install .Net Core 3.1 - 64bits](https://dotnet.microsoft.com/download/dotnet-core/thank-you/sdk-3.1.403-windows-x64-installer)

 - path in project: `api/`

### Interface 
Made with Angular 10, using "Angular Material" for library components.

 - if you already have nodejs installed --> `npm install -g @angular/cli`

 - if you have not --> [Install Nodejs](https://nodejs.org/en/) then run the command above

 - path in project: `frontend-backend/`

## :rocket: Running

#### Getting the project

- `git clone https://github.com/ropoko/Angular-NetCore.git`

- `cd Angular-NetCore/`

- If you´re using vscode --> `code .`

#### Database

- On localhost create an database named "apiAngular" or change the configurarions in api/appsetting.json

- `create database apiAngular`

#### Api

- go into path `cd api/`

- run `dotnet build`

- using migrations `dotnet ef migrations add Initial --context ContextMySql`

- commit migration `dotnet ef database update --context ContextMySql`

- then run the api: `dotnet run`

#### Angular

- go into path `cd frontend-backend/`

- run `npm install`

- if any problem appears `npm audit fix`

- then run the interface: `ng serve`
