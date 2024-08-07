﻿using HealthMed.Domain.Models.Autenticacao;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace HealthMed.Infra.Data.Mappings.Autenticacao
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.DataInclusao);

            builder.Property(x => x.Nome).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Login).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Senha).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Salt).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Email).IsRequired(false).HasMaxLength(100);
            builder.Property(x => x.Cpf).IsRequired();
            builder.Property(x => x.CRM).HasMaxLength(50);

            builder.Property(x => x.Excluido).HasDefaultValue(false);

            builder.HasOne(x => x.Especialidade).WithMany().HasForeignKey(x => x.IdEspecialidade);
            builder.HasOne(x => x.Perfil).WithMany().HasForeignKey(x => x.IdPerfil).IsRequired();
        }
    }
}
