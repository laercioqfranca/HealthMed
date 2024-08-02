using HealthMed.Domain.Models.Medico;

namespace HealthMed.Domain.Interfaces.Infra.Data.Repositories.Medico
{
    public interface IAgendaMedicaRepository : IRepository<AgendaMedica>
    {
        Task<IEnumerable<AgendaMedica>> GetByFilter(DateTime? data, Guid? idHorario, Guid? idMedico, Guid? idPaciente);
        Task<AgendaMedica?> GetById(Guid id, bool? agendado);
        Task<IEnumerable<AgendaMedica>> GetListByIdMedico(Guid idMedico);
    }
}
