﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthMed.Domain.Models.Autenticacao;

namespace HealthMed.Domain.Interfaces.Infra.Data.Repositories.Auth
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Task<IEnumerable<Usuario>> GetAll();
        Task<Usuario> GetById(Guid id);
        Task<IEnumerable<Usuario>> GetByLogin(string login);
        Task<IEnumerable<Usuario>> GetByFiltro(string nome, string email, string cpf);
        Task<List<Usuario>> GetListByIdEspecialidade(Guid idEspecialidade);
    }
}
