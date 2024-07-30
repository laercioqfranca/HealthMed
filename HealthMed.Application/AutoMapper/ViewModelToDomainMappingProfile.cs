using AutoMapper;
using HealthMed.Application.DTO;
using HealthMed.Application.ViewModels.Auth;
using HealthMed.Domain.Commands.Administracao;
using HealthMed.Domain.Commands.Auth;

namespace HealthMed.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<LoginViewModel, AutenticarCommand>();

            CreateMap<UsuarioDTO, UsuarioCreateCommand>();

            CreateMap<UsuarioViewModel, UsuarioUpdateCommand>();
        }
    }
}