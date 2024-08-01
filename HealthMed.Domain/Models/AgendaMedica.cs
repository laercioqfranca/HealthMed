using HealthMed.Core.Models;
using HealthMed.Domain.Models.Autenticacao;
using HealthMed.Domain.Models.TabelaDominio;

namespace HealthMed.Domain.Models
{
    public class AgendaMedica : Entity
    {
        public DateTime Data { get; private set; }
        public Guid IdHorario { get; private set; }
        public Guid IdMedico { get; private set; }
        public Guid? IdPaciente { get; private set; }
        public AgendaMedica(DateTime data, Guid idHorario, Guid idMedico, Guid? idPaciente)
        {
            Data = data;
            IdHorario = idHorario;
            IdMedico = idMedico;
            IdPaciente = idPaciente;
        }

        public virtual Horario Horario { get; private set; }
        public virtual Usuario Medico { get; private set; }
        public virtual Usuario? Paciente { get; private set; }
    }
}
