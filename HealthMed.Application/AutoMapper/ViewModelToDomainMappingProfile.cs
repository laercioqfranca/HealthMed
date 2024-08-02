using AutoMapper;
using HealthMed.Application.DTO;
using HealthMed.Application.ViewModels.Auth;
using HealthMed.Domain.Commands.Administracao;
using HealthMed.Domain.Commands.Auth;
using HealthMed.Domain.Commands.Medico;
using HealthMed.Domain.Commands.Paciente;
using static HealthMed.Domain.Commands.Medico.AgendaMedicaCreateCommand;

namespace HealthMed.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<LoginViewModel, AutenticarCommand>();

            CreateMap<UsuarioDTO, UsuarioCreateCommand>();

            CreateMap<PacienteViewModel, UsuarioUpdateCommand>();

            CreateMap<AgendaMedicaDTO, AgendaMedicaCreateCommand>();
            CreateMap<AgendaDTO, AgendaCreateCommand>();

            CreateMap<AgendaPacienteDTO, AgendaPacienteCreateCommand>();
            CreateMap<AgendaPacienteDTO, AgendaPacienteDeleteCommand>();
        }
    }
}