using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using HealthMed.Domain.Models.TabelaDominio;

namespace HealthMed.Infra.Data.Mappings.TabelaDominio
{
    public class HorarioMap : IEntityTypeConfiguration<Horario>
    {
        public void Configure(EntityTypeBuilder<Horario> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.DataInclusao);

            builder.Property(x => x.Descricao).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Excluido).HasDefaultValue(false);
        }
    }
}
