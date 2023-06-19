## WebIssueManagementApp
### Aplicativo para gerenciamento de tarefas no apoio ao desenvolvedor

#### Tecnologias: 
1. C#
2. Entity Framework
3. Aspnet
4. NET Core 6
5. SQL Server 2022
6. Bootstrap 5.
7. Autenticação\Autorização via Cookie

#### Padrões de Projetos
1. Repository
2. Unit of Work
3. Dependency injection
4. Programação Orientação a Objetos.

### Instruções para execução do projeto:

usuário: admin@issuemanager.com
senha: teste@123

#### Execução da Aplicação utilizando docker compose

Alterar o arquivo: docker-compose.yml

volumes: Inserir um diretório válido de seu computador para salvar os arquivos criados do banco de dados sql server. exemplo: c:\temp

Executar o comando:
```docker-compose up --build```

#### Execução da Aplicação utilizando docker

Executar o primeiro passo.

Alterar o arquivo launchSettings.json Docker.environmentVariables.DB_HOST com o IP local do seu computador 

Exemplo  ```"DB_HOST": "192.168.64.1"```


#### Execução da Aplicação utilizando ISS express ou executável

Executar o primeiro passo.

Executar a aplicação normalmente pelo visual studio ou vs code.


### Telas do App

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
