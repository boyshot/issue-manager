## Issue manager app
### Task management application for developer support

#### Technologies: 
1. c#
2. entity framework core
3. aspnet
4. net core 6
5. sql server 2022
6. bootstrap 5.
7. authentication\authorization with cookie

#### Design Patterns
1. Repository
1. Unit of Work
1. Dependency injection

#### Architecture
1. MVC

### Project admin access instructions

user: admin@issuemanager.com
password: teste@123

#### Application execution using docker compose

Run the command:
```docker-compose up --build```

#### Application execution using docker

Run the first step.

Change the file launchSettings.json Docker.environmentVariables.DB_HOST with your computer's local ip

example  ```"DB_HOST": "192.168.64.1"```

#### Application execution using IIs or Executable 

Run the first step.

Run the application normally through visual studio or vscode.

### Just use the app
Access the link: [dockehub image](https://hub.docker.com/r/paulorocha/issue-manager) e executar o arquivo docker compose localmente

### Screen app

#### Home
![Home](https://github.com/boyshot/WebIssueManagementApp/blob/main/ImageProject/Tela001Home.png)

#### Issue
![Issue](https://github.com/boyshot/WebIssueManagementApp/blob/main/ImageProject/Tela001Issue.png)

#### Issue\edit
![Issue -> Edit](https://github.com/boyshot/WebIssueManagementApp/blob/main/ImageProject/Tela001IssueEdit.png)

#### Issue\attach
![Issue -> Attach](https://github.com/boyshot/WebIssueManagementApp/blob/main/ImageProject/Tela001IssueAttach.png)

#### Login
![Login](https://github.com/boyshot/WebIssueManagementApp/blob/main/ImageProject/Tela001Login.png)
