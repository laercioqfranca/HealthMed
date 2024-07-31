﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using HealthMed.Domain.Models;

namespace HealthMed.Infra.Data.Mappings
{
    public class EspecialidadeMap : IEntityTypeConfiguration<Especialidade>
    {
        public void Configure(EntityTypeBuilder<Especialidade> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.DataInclusao);

            builder.Property(x => x.Descricao).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Excluido).HasDefaultValue(false);
        }
    }
}