using AutoMapper;
using HealthMed.Application.DTO;
using HealthMed.Application.ViewModels.Auth;
using HealthMed.Application.ViewModels.TabelaDominio;
using HealthMed.Domain.Commands;
using HealthMed.Domain.Models.Autenticacao;
using HealthMed.Domain.Models.TabelaDominio;
using static HealthMed.Domain.Commands.AgendaMedicaCreateCommand;

namespace HealthMed.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {        
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Usuario, LoginViewModel>().ReverseMap();

            CreateMap<Usuario, UsuarioViewModel>();
            CreateMap<PerfilUsuario, PerfilUsuarioViewModel>();

            CreateMap<Especialidade, EspecialidadeViewModel>();
            CreateMap<Horario, HorarioViewModel>();


            CreateMap<AgendaMedicaDTO, AgendaMedicaCreateCommand>();
            CreateMap<AgendaDTO, AgendaCreateCommand>();

        }
    }
}
