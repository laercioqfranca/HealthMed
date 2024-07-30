using HealthMed.Core.Models;

namespace HealthMed.Domain.Models.Autenticacao
{
    public class PerfilUsuario : Entity
    {
        public string Descricao { get; private set; }
        public bool Excluido { get; private set; }

        public DateTime DataInclusao { get; private set; }

        public virtual IEnumerable<ClaimPerfil> ClaimsPerfil { get; private set; }

    }
}