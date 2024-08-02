using AutoMapper;
using HealthMed.Application.ViewModels.Auth;
using HealthMed.Application.ViewModels.Medico;
using HealthMed.Application.ViewModels.Paciente;
using HealthMed.Application.ViewModels.TabelaDominio;
using HealthMed.Domain.Models.Autenticacao;
using HealthMed.Domain.Models.Medico;
using HealthMed.Domain.Models.Paciente;
using HealthMed.Domain.Models.TabelaDominio;

namespace HealthMed.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {        
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Usuario, LoginViewModel>().ReverseMap();

            CreateMap<Usuario, PacienteViewModel>();
            CreateMap<PerfilUsuario, PerfilUsuarioViewModel>();

            CreateMap<Especialidade, EspecialidadeViewModel>();
            CreateMap<Horario, HorarioViewModel>();

            CreateMap<AgendaMedica, AgendaMedicaViewModel>()
                .ForMember(dest => dest.NomeMedico, opt => opt.MapFrom(opt => opt.Medico.Nome))
                .ForMember(dest => dest.DataConsulta, opt => opt.MapFrom(opt => opt.Data.ToString("dd/MM/yyyy")))
                .ForMember(dest => dest.HorarioConsulta, opt => opt.MapFrom(opt => opt.Horario.Descricao));

            CreateMap<AgendaPaciente, AgendaPacienteViewModel>()
                .ForMember(dest => dest.NomeMedico, opt => opt.MapFrom(opt => opt.AgendaMedica.Medico.Nome))
                .ForMember(dest => dest.EspecialidadeMedica, opt => opt.MapFrom(opt => opt.AgendaMedica.Medico.Especialidade.Descricao))
                .ForMember(dest => dest.DataConsulta, opt => opt.MapFrom(opt => opt.AgendaMedica.Data.ToString("dd/MM/yyyy")))
                .ForMember(dest => dest.HorarioConsulta, opt => opt.MapFrom(opt => opt.AgendaMedica.Horario.Descricao));

            CreateMap<Usuario, UsuarioMedicoViewModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(opt => opt.Id))
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(opt => opt.Nome))
                .ForMember(dest => dest.CRM, opt => opt.MapFrom(opt => opt.CRM))
                .ForMember(dest => dest.Especialidade, opt => opt.MapFrom(opt => opt.Especialidade.Descricao));

        }
    }
}
