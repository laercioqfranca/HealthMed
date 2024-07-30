using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using HealthMed.Infra.Data.Mappings;
using HealthMed.Infra.Data.Mappings.Autenticacao;
using System;

namespace HealthMed.Infra.Data.Context
{
    public class HealthMedContext : DbContext
    {
        public HealthMedContext(DbContextOptions<HealthMedContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder().SetBasePath(AppDomain.CurrentDomain.BaseDirectory).AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json").Build();
            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new PerfilUsuarioMap());
            modelBuilder.ApplyConfiguration(new ClaimUsuarioMap());
            modelBuilder.ApplyConfiguration(new ClaimPerfilMap());
            modelBuilder.ApplyConfiguration(new AgendaMedicaMap());
            modelBuilder.ApplyConfiguration(new EspecialidadeMap());
            modelBuilder.ApplyConfiguration(new HorarioMap());


            #region Mapeamento das Tabelas de tipos e domínios

            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}
