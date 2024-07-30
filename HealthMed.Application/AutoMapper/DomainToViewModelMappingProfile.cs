using AutoMapper;
using HealthMed.Application.ViewModels.Auth;
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

        }
    }
}
