using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using HealthMed.Domain.Models.Medico;

namespace HealthMed.Infra.Data.Mappings
{
    public class AgendaMedicaMap : IEntityTypeConfiguration<AgendaMedica>
    {
        public void Configure(EntityTypeBuilder<AgendaMedica> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Data).IsRequired();
            builder.Property(x => x.Agendado).IsRequired().HasDefaultValue(false);

            builder.HasOne(x => x.Horario).WithMany().HasForeignKey(x => x.IdHorario).IsRequired();
            builder.HasOne(x => x.Medico).WithMany().HasForeignKey(x => x.IdMedico).IsRequired();
        }
    }
}
