using HealthMed.Domain.Models.Paciente;

namespace HealthMed.Domain.Interfaces.Infra.Data.Repositories.Paciente
{
    public interface IAgendaPacienteRepository : IRepository<AgendaPaciente>
    {
        Task<AgendaPaciente?> GetById(Guid idAgendaMedica);
        Task<IEnumerable<AgendaPaciente>> GetAll();
    }
}
