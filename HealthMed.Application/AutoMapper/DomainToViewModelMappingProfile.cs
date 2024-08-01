using AutoMapper;
using HealthMed.Application.DTO;
using HealthMed.Application.ViewModels;
using HealthMed.Application.ViewModels.Auth;
using HealthMed.Application.ViewModels.TabelaDominio;
using HealthMed.Domain.Commands;
using HealthMed.Domain.Models;
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

            CreateMap<AgendaMedica, AgendaMedicaViewModel>()
                .ForMember(dest => dest.NomeMedico, opt => opt.MapFrom(opt => opt.Medico.Nome))
                .ForMember(dest => dest.DataConsulta, opt => opt.MapFrom(opt => opt.Data.ToString("dd/MM/yyyy")))
                .ForMember(dest => dest.HorarioConsulta, opt => opt.MapFrom(opt => opt.Horario.Descricao));

        }
    }
}
