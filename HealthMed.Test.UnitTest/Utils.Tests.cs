using HealthMed.Domain.Models.Autenticacao;

namespace HealthMed.Test.UnitTest
{
    public class Utils
    {
        public static bool CaracteresObrigatorios(string senha)
        {
            string[] caracteresValidos = ["ABCDEFGHIJKLMNOPQRSTUVWXYZ", "abcdefghijklmnopqrstuvwxyz", "0123456789", "!@#$%^&*()_+"];

            bool resultado = true;

            // Percorre cada grupo de caracteres v�lidos
            for (int i = 0; i < caracteresValidos.Length; i++)
            {
                bool grupoEncontrado = false;

                // Verifica se ao menos um caractere do grupo est� presente na senha
                foreach (char c in senha)
                {
                    if (caracteresValidos[i].Contains(c))
                    {
                        grupoEncontrado = true;
                        break; // Se encontrou um caractere do grupo, pode sair do loop
                    }
                }

                // Se o grupo n�o foi encontrado na senha, ent�o a senha n�o atende aos requisitos
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