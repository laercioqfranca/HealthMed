using HealthMed.Domain.Models.Autenticacao;

namespace HealthMed.Test.UnitTest
{
    public class TesteNovaSenha
    {
        [Theory]
        [InlineData(20)]
        public void VerificaCaracteresObrigatoriosEmSenhasGeradas(int quantidade)
        {
            // Arrange
            Usuario usuario = new Usuario();
            List<string> senhasGeradas = new List<string>();

            List<(string, bool)> validacoes = new List<(string, bool)>();
            bool senhaValidas = false;

            for (int i = 0; i < quantidade; i++)
            {
                senhasGeradas.Add(usuario.GerarSenhaAleatoria());
            }

            // Act
            foreach (var senha in senhasGeradas)
            {
                senhaValidas = Utils.CaracteresObrigatorios(senha);
                if (senhaValidas == false) break;

                validacoes.Add((senha, senhaValidas));
            }

            // Assert
            Assert.True(senhaValidas);
        }

        [Fact]
        public void VerificaSeASenhaEstaNulaOuVazia()
        {
            // Arrange
            Usuario usuario = new Usuario();

            // Act
            string senhaGerada = usuario.GerarSenhaAleatoria();

            // Assert
            Assert.NotNull(senhaGerada);
            Assert.NotEmpty(senhaGerada);
        }

        [Fact]
        public void VerificaSenhaPadrao()
        {
            // Arrange
            Usuario usuario = new Usuario();

            // Act
            usuario.DefinirCriptografia(null, null);

            // Assert
            Assert.True(usuario.ValidarSenhaCorreta(usuario.Senha, usuario.Salt, "IntranetCicc@2024"));
        }
    }
}