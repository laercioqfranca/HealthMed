using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using HealthMed.Application.Interfaces.Administracao;
using HealthMed.Application.ViewModels.Administracao;
using HealthMed.Core.Interfaces;
using HealthMed.Domain.Commands.Administracao;
using HealthMed.Domain.Interfaces.Infra.Data.Repositories.Auth;
using HealthMed.Application.ViewModels.Auth;
using HealthMed.Application.DTO;

namespace HealthMed.Application.AppServices.Administracao
{
    public class UsuarioAppService : IUsuarioAppService
    {
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _bus;
        private readonly IUsuarioRepository _repository;
        private readonly IHttpContextAccessor _httpContextAcessor;

        public UsuarioAppService(IMapper mapper, IMediatorHandler bus, IUsuarioRepository repository, IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _bus = bus;
            _repository = repository;
            _httpContextAcessor = httpContextAccessor;
        }

        public async Task<IEnumerable<PacienteViewModel>> GetAll()
        {
            var usuarios = await _repository.GetAll();
            return _mapper.Map<IEnumerable<PacienteViewModel>>(usuarios);
        }

        public async Task<PacienteViewModel> GetById(Guid id)
        {
            var query = await _repository.GetById(id);
            return _mapper.Map<IEnumerable<PacienteViewModel>>(query).FirstOrDefault();
        }

        public async Task<IEnumerable<UsuarioMedicoViewModel>> GetListByIdEspecialidade(Guid idEspecialidade)
        {
            var usuarios = await _repository.GetListByIdEspecialidade(idEspecialidade);
            return _mapper.Map<IEnumerable<UsuarioMedicoViewModel>>(usuarios);
        }

        public async Task<PacienteViewModel> GetByLogin(string login)
        {
            var query = await _repository.GetByLogin(login);
            return _mapper.Map<IEnumerable<PacienteViewModel>>(query).FirstOrDefault();
        }

        public async Task<IEnumerable<PacienteViewModel>> GetByFiltro(ConsultarPorFiltroViewModel filtro)
        {
            var usuarios = await _repository.GetByFiltro(filtro.Nome, filtro.CPF, filtro.Email);
            return _mapper.ProjectTo<PacienteViewModel>(usuarios.AsQueryable());
        }

        public async Task Create(UsuarioDTO usuarioDTO)
        {
            var command = _mapper.Map<UsuarioCreateCommand>(usuarioDTO);
            await _bus.SendCommand(command);
        }

        public async Task Update(PacienteViewModel model)
        {
            var command = _mapper.Map<UsuarioUpdateCommand>(model);
            await _bus.SendCommand(command);
        }

        public async Task Delete(Guid id)
        {
            var command = new UsuarioDeleteCommand(id);
            await _bus.SendCommand(command);

        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}
