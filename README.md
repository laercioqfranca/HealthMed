#### [Postech - FIAP - Arquitetura de Sistemas com .NET e Azure]
# Health&Med

## Sobre
Health&Med é um sistema para registro de agenda médica e cadastro de consultas.


## Criação de conta
* Para cadastro de conta, o usuário selecioa o tipo de perfil (Médico ou Paciente)

<a href="#">![Tela criar conta](HealthMed.Web/ClientApp/src/assets/img/tela_criar_conta.png "Tela criar conta")</a>
<a href="#">![Json criar usuário](HealthMed.Web/ClientApp/src/assets/img/json_criar_usuario.png "Json criar usuário")</a>


## Autenticação
* O processo de autenticação envolve envio de e-mail e senha pelo frontend.
* Para maior segurança foi utilizada criptografia de login e senha pelo frontend que é resolvida na controller de autenticação.
  
<a href="#">![Tela de login](HealthMed.Web/ClientApp/src/assets/img/tela_login.png "Tela de login")</a>  
<a href="#">![Autenticação](HealthMed.Web/ClientApp/src/assets/img/autenticacao_json.png "Autenticação")</a>



# Tecnologias utilizadas
* .NET 8
* EntityFrameworkCore
* SQL Server
* Angular 16
