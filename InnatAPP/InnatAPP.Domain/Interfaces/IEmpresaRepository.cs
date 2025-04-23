using System.Threading.Tasks;
using InnatAPP.Domain.Entities;
using System.Collections.Generic;

namespace InnatAPP.Domain.Interfaces
{
    public interface IEmpresaRepository
    {
        Task<IEnumerable<Empresa>> BuscarEmpresasAsync();
        Task<Empresa> BuscarEmpresaPorIdAsync(int id);

        Task<Empresa> CriarEmpresaAsync(Empresa empresa);
        Task<Empresa> AtualizarEmpresaAsync(Empresa empresa);
        Task<Empresa> DeletarEmpresaAsync(Empresa empresa);
    }
}
