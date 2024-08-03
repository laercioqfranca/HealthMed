using HealthMed.Domain.Models.Autenticacao;

namespace HealthMed.Test.UnitTest
{
    public class Utils
    {
        public static bool CaracteresObrigatorios(string senha)
        {
            string[] caracteresValidos = ["ABCDEFGHIJKLMNOPQRSTUVWXYZ", "abcdefghijklmnopqrstuvwxyz", "0123456789", "!@#$%^&*()_+"];

            bool resultado = true;

            // Percorre cada grupo de caracteres válidos
            for (int i = 0; i < caracteresValidos.Length; i++)
            {
                bool grupoEncontrado = false;

                // Verifica se ao menos um caractere do grupo está presente na senha
                foreach (char c in senha)
                {
                    if (caracteresValidos[i].Contains(c))
                    {
                        grupoEncontrado = true;
                        break; // Se encontrou um caractere do grupo, pode sair do loop
                    }
                }

                // Se o grupo não foi encontrado na senha, então a senha não atende aos requisitos
                if (!grupoEncontrado)
                {
                    resultado = false;
                    break;
                }
            }

            return resultado;
        }
    }
}