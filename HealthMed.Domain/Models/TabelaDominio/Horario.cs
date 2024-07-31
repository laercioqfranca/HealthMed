using HealthMed.Core.Models;

namespace HealthMed.Domain.Models.TabelaDominio
{
    public class Horario : Entity
    {
        public string Descricao { get; private set; }
        public DateTime DataInclusao { get; private set; }
        public bool Excluido { get; private set; }
    }
}
