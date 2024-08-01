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
            setCriptografia(senha, null);
        }

        public void setExcluido(bool excluido)
        {
            Excluido = excluido;
        }

        public string setGerarSenhaAleatoria()
        {
            string senhagerada = CreateRandomPassword();
            setCriptografia(senhagerada, "");
            return senhagerada;
        }

        public void setCriptografia(string senha, string salt)
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

        private static string CreateRandomPassword(int length = 8)
        {
            // Create a string of characters, numbers, special characters that allowed in the password  
            string validChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            Random random = new Random();

            // Select one random character at a time from the string  
            // and create an array of chars  
            char[] chars = new char[length];
            for (int i = 0; i < length; i++)
            {
                chars[i] = validChars[random.Next(0, validChars.Length)];
            }
            return new string(chars);
        }
    }
}