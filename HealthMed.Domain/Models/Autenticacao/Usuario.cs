using HealthMed.Core.Models;
using HealthMed.Domain.Models.TabelaDominio;
using HealthMed.Domain.Utils;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HealthMed.Domain.Models.Autenticacao
{
    public class Usuario : Entity
    {
        public Usuario()
        {
        }

        public string Nome { get; private set; }
        public string Login { get; private set; }
        public string Senha { get; private set; }
        public string Salt { get; private set; }
        public string Email { get; private set; }
        public long Cpf { get; private set; }
        public string? CRM { get; private set; }
        public Guid? IdEspecialidade { get; private set; }
        public Guid? IdPerfil { get; private set; }
        public DateTime DataInclusao { get; private set; }
        public bool Excluido { get; private set; }

        public virtual Especialidade Especialidade { get; private set; }
        public virtual PerfilUsuario Perfil { get; private set; }


        public void setUsuario(Guid id, string nome, string senha, string email, long cpf, Guid? idPerfil, string? cRM, Guid? idEspecialidade)
        {
            Id = id;
            Nome = nome;
            Email = email;
            IdPerfil = idPerfil;        
            Login = email;
            Cpf = cpf;
            CRM = cRM;
            IdEspecialidade = idEspecialidade;
            DataInclusao = DateTime.Now;
            DefinirCriptografia(senha, null);
        }

        public void setExcluido(bool excluido)
        {
            Excluido = excluido;
        }

        public string GerarSenhaAleatoria()
        {
            string senhagerada = CreateRandomPassword();
            DefinirCriptografia(senhagerada, "");
            return senhagerada;
        }

        public void DefinirCriptografia(string senha, string salt)
        {
            Salt = string.IsNullOrEmpty(salt) ? Cryptography.GetSalt() : salt;
            Senha = Cryptography.GetHash(Salt, string.IsNullOrEmpty(senha) ? "Agendamento@2024" : senha);
        }

        public void setUpdateUsuario(string nome, string email, Guid? idPerfil)
        {
            Nome = nome;
            Email = email;
            IdPerfil = idPerfil;
            Perfil = null;
        }

        public bool ValidarSenhaCorreta(string senhaDoBanco, string saltDoBanco, string senhaInformada)
        {
            string resultado = Cryptography.GetHash(saltDoBanco, senhaInformada);
            return resultado == senhaDoBanco;
        }

        private static string CreateRandomPassword(int length = 8)
        {
            Random random = new Random();
            char[] chars = new char[length];

            string upperCase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string lowerCase = "abcdefghijklmnopqrstuvwxyz";
            string number = "0123456789";
            string symbols = "!@#$%^&*()_+";

            string[] charactersGroup = { upperCase, lowerCase, number, symbols };

            // Seleciona pelo menos um caractere de cada grupo
            for (int i = 0; i < charactersGroup.Length; i++)
            {
                string selectedCharacter = charactersGroup[i];
                chars[i] = selectedCharacter[random.Next(0, selectedCharacter.Length)];
            }

            // Preenche o restante da senha com caracteres aleatórios
            for (int i = charactersGroup.Length; i < length; i++)
            {
                string selectedCharacter = charactersGroup[random.Next(0, charactersGroup.Length)];
                chars[i] = selectedCharacter[random.Next(0, selectedCharacter.Length)];
            }

            // Embaralha os caracteres para garantir aleatoriedade
            for (int i = 0; i < length; i++)
            {
                int randIndex = random.Next(i, length);
                char temp = chars[i];
                chars[i] = chars[randIndex];
                chars[randIndex] = temp;
            }

            return new string(chars);
        }
    }
}