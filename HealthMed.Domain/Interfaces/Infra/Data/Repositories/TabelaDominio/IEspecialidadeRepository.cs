using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthMed.Domain.Enum;
using HealthMed.Domain.Models.Autenticacao;
using HealthMed.Domain.Models.TabelaDominio;

namespace HealthMed.Domain.Interfaces.Infra.Data.Repositories.TabelaDominio
{
    public interface IEspecialidadeRepository
    {
        Task<IEnumerable<Especialidade>> GetAll();
    }
}
