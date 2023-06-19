# WebIssueManagementApp
Aplicativo para Gerenciamentos de Issues do Desenvolvedor

Tecnologias: C#, EntityFramework, Razor, MVC, .NET core 6, Banco de Dados SQL Server 2022 e Bootstrap 5.

- Autenticação\Autorização via Cookie

Padrões de Projetos: Repository, Unit of Work, DI, Orientação a Objetos.

Instruções para execução do projeto:

Usuário default:
usuário: admin@issuemanager.com
senha: teste@123

Execução da Aplicação utilizando docker compose

Alterar o arquivo: docker-compose.yml

em volumes: Inserir um diretório válido de seu computador para salvar os arquivos criados do banco de dados sql server. exemplo: c:\temp

Executar o comando: docker-compose up --build


Telas do App

Home
![Home](https://github.com/boyshot/WebIssueManagementApp/blob/main/ImageProject/Tela001Home.png)

Issue
![Issue](https://github.com/boyshot/WebIssueManagementApp/blob/main/ImageProject/Tela001Issue.png)

Issue\edit
![Issue -> Edit](https://github.com/boyshot/WebIssueManagementApp/blob/main/ImageProject/Tela001IssueEdit.png)

Issue\attach
![Issue -> Attach](https://github.com/boyshot/WebIssueManagementApp/blob/main/ImageProject/Tela001IssueAttach.png)

login
![Login](https://github.com/boyshot/WebIssueManagementApp/blob/main/ImageProject/Tela001Login.png)
