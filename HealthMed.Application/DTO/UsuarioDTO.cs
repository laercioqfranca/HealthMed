using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthMed.Application.DTO
{
    public class UsuarioDTO
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public long Cpf { get; set; }
        public string? CRM { get; set; }
        public Guid? IdPerfil { get; set; }
        public Guid? IdEspecialidade { get; set; }

    }
}
