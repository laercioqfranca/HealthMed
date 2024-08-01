using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using HealthMed.Domain.Models.Paciente;

namespace HealthMed.Infra.Data.Mappings
{
    public class AgendaPacienteMap : IEntityTypeConfiguration<AgendaPaciente>
    {
        public void Configure(EntityTypeBuilder<AgendaPaciente> builder)
        {

            builder.HasKey(x => new { x.IdAgendaMedica, x.IdPaciente });

            builder.HasIndex(x => x.IdAgendaMedica).IsUnique();

            builder.HasOne(x => x.AgendaMedica).WithMany().HasForeignKey(x => x.IdAgendaMedica).Metadata.DeleteBehavior = DeleteBehavior.Restrict;
            builder.HasOne(x => x.Paciente).WithMany().HasForeignKey(x => x.IdPaciente).Metadata.DeleteBehavior = DeleteBehavior.Restrict;
        }
    }
}
