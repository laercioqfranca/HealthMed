#### [Postech - FIAP - Arquitetura de Sistemas com .NET e Azure]
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


# Tecnologias utilizadas
* .NET 8
* EntityFrameworkCore
* SQL Server
* Angular 16
