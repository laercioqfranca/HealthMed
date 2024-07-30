using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using HealthMed.Domain.Models.Autenticacao;

namespace HealthMed.Infra.Data.Mappings.Autenticacao
{
    public class ClaimUsuarioMap : IEntityTypeConfiguration<ClaimUsuario>
    {
        public void Configure(EntityTypeBuilder<ClaimUsuario> builder)
        {
            builder.HasKey(x => x.Id);            
            builder.Property(x => x.Descricao).IsRequired().HasMaxLength(100);
            builder.Property(x => x.DataInclusao);
            builder.Property(x => x.Excluido).HasDefaultValue(false);
        }
    }
}
