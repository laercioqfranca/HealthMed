using AutoMapper;
using HealthMed.Application.DTO;
using HealthMed.Application.ViewModels.Auth;
using HealthMed.Domain.Commands;
using HealthMed.Domain.Commands.Administracao;
using HealthMed.Domain.Commands.Auth;
using static HealthMed.Domain.Commands.AgendaMedicaCreateCommand;

namespace HealthMed.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<LoginViewModel, AutenticarCommand>();

            CreateMap<UsuarioDTO, UsuarioCreateCommand>();

            CreateMap<UsuarioViewModel, UsuarioUpdateCommand>();

            CreateMap<AgendaMedicaDTO, AgendaMedicaCreateCommand>();
            CreateMap<AgendaDTO, AgendaCreateCommand>();

            CreateMap<AgendaPacienteDTO, AgendaPacienteCreateCommand>();
        }
    }
}