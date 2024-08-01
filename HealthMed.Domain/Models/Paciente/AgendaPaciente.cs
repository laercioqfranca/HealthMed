using HealthMed.Domain.Models.Autenticacao;
using HealthMed.Domain.Models.Medico;
namespace HealthMed.Domain.Models.Paciente
{
    public class AgendaPaciente
    {
        public Guid IdAgendaMedica { get; private set; }
        public Guid IdPaciente { get; private set; }
        public virtual AgendaMedica AgendaMedica { get; private set; }
        public virtual Usuario Paciente { get; private set; }

        public AgendaPaciente(Guid idAgendaMedica, Guid idPaciente)
        {
            IdAgendaMedica = idAgendaMedica;
            IdPaciente = idPaciente;
        }
    }
}
