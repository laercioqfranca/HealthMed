using HealthMed.Domain.Models.Autenticacao;
using HealthMed.Domain.Utils;

namespace HealthMed.Test.UnitTest
{
    public class TesteSenhaLogin
    {
        [Theory]
        [InlineData("minhaSenha$102")]
        public void VerificaValidadeDaSenhaInformada(string senhaInformada)
        {
            // Arrange

            // Act
            string senhaValida = Utils.CaracteresObrigatorios(senhaInformada) ? "Válida" : "Inválida";

            // Assert
            Assert.NotNull(senhaInformada);
            Assert.NotEmpty(senhaInformada);
            Assert.True(senhaInformada.Length >= 8);
            Assert.Equal("Válida", senhaValida);
        }

        [Theory]
        [InlineData("minhaSenha$102", "minhaSenha$102")]
        public void VerificaSenhaCorreta(string senhaAtual, string senhaInformada)
        {
            // Arrange
            Usuario usuario = new Usuario();
            usuario.DefinirCriptografia(senhaAtual, null);

            // Act
            bool senhaCorreta = usuario.ValidarSenhaCorreta(usuario.Senha, usuario.Salt, senhaInformada);

            // Assert
            Assert.True(senhaCorreta);
        }


    }
}