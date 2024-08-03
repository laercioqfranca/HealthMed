#### [Hackathon - FIAP - Arquitetura de Sistemas com .NET e Azure]
# Health&Med

## Sobre
Health&Med é um sistema para registro de agenda médica e cadastro de consultas.

-----
# Principais funcionalidades do sistema

-----
## Criação de conta
* Para cadastro de conta, o usuário selecioa o tipo de perfil (Médico ou Paciente)

<a href="#">![Tela criar conta](HealthMed.Web/ClientApp/src/assets/img/tela_criar_conta.png "Tela criar conta")</a>
<a href="#">![Json criar usuário](HealthMed.Web/ClientApp/src/assets/img/json_criar_usuario.png "Json criar usuário")</a>

-----
## Autenticação
* O processo de autenticação envolve envio de e-mail e senha pelo frontend.
* Para maior segurança, foi utilizada criptografia de login e senha pelo frontend que é resolvida na controller de autenticação.
  
<a href="#">![Tela de login](HealthMed.Web/ClientApp/src/assets/img/tela_login.png "Tela de login")</a>  
<a href="#">![Autenticação](HealthMed.Web/ClientApp/src/assets/img/autenticacao_json.png "Autenticação")</a>

-----
## Cadastro de agenda médica
* Para cadastar agenda, o médico seleciona a data desejada e a lista de horários disponíveis.
* Ao salvar, a agenda é imediatamente atualizada na parte inferior da tela do médico.
* O botão de um horário fica com texto azul indicando agendamento cadastrado por algum paciente.
  
<a href="#">![Tela cadastrar agenda](HealthMed.Web/ClientApp/src/assets/img/cadastrar_agenda.png "Tela cadastrar agenda")</a>
<a href="#">![Json cadastrar agenda](HealthMed.Web/ClientApp/src/assets/img/json_criar_agenda.png "Json cadastrar agenda")</a>

-----
## Agendamento de consulta
* Para cadastrar uma consulta, o paciente seleciona uma especialidade médica que libera a lista de médicos correspondentes.
* Ao selecionar o médico, sua agenda com data e horários são disponibilizados para seleção. 
* Clicando em 'Agendar Consulta', a tabela 'Minhas Consultas' é automaticamente atualizada.

<a href="#">![Tela cadastrar consulta](HealthMed.Web/ClientApp/src/assets/img/tela_cadastrar_consulta.png "Tela cadastrar consulta")</a>
<a href="#">![Json cadastrar consulta](HealthMed.Web/ClientApp/src/assets/img/json_agendar_consulta.png "Json cadastrar consulta")</a>

-----

## Notificação de consulta agendada
* Quando um paciente agenda uma consulta, o médico recebe por e-mail a notificação da consulta marcada
  
<a href="#">![Notificação](HealthMed.Web/ClientApp/src/assets/img/notificacao.png "Notificação")</a>

-----
## API completa do sistema
<a href="#">![Swagger](HealthMed.Web/ClientApp/src/assets/img/swagger.png "Swagger")</a>


## Modelagem do banco de dados
<a href="#">![Modelagem](HealthMed.Web/ClientApp/src/assets/img/modelagem.png "Modelagem")</a>

-----
## Executar o projeto
* Para executar o projeto, clique com o botão direito no projeto web "HealthMed.Web", selecione "Set as Startup Project" e no botão "executar" na parte superior central, selecione "IIS Express" e clique em executar para carregar a página do Swagger.
* Para executar o Front-End(Angular) utilizando o Visual Studio Code:
    *  Clique em "Open Folder..." e selecione a pasta "HealthMed\HealthMed.Web\ClientApp".
    *  Em seguida no terminal do Visual Studio Code, execute o comando "npm install" para baixar os pacotes.
    *  Por fim "ng serve -o" para executar a aplicação e abrir a página de login.

# Tecnologias utilizadas
* .NET 8
* EntityFrameworkCore
* SQL Server
* Angular 16
