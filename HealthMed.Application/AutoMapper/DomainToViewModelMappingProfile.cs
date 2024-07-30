using AutoMapper;
using HealthMed.Application.ViewModels;
using HealthMed.Application.ViewModels.Auth;
using HealthMed.Domain.Models;
using HealthMed.Domain.Models.Autenticacao;

namespace HealthMed.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {        
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Usuario, LoginViewModel>().ReverseMap();

            CreateMap<Usuario, UsuarioViewModel>();
            CreateMap<PerfilUsuario, PerfilUsuarioViewModel>();

            CreateMap<Eventos, EventoViewModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.ToString()));
                //.ForMember(dest => dest.Data, opt => opt.MapFrom(src => src.Data.ToString("dd/MM/yyyy")));

        }
    }
}
