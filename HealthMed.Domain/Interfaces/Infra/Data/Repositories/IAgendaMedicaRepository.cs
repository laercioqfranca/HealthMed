using HealthMed.Domain.Models;
using HealthMed.Domain.Models.Autenticacao;

namespace HealthMed.Domain.Interfaces.Infra.Data.Repositories
{
    public interface IAgendaMedicaRepository : IRepository<AgendaMedica>
    {
        Task<IEnumerable<AgendaMedica>> GetByFilter(DateTime? data, Guid? idHorario, Guid? idMedico, Guid? idPaciente);
        Task<AgendaMedica?> GetById(Guid id, bool? agendado);
    }
}
