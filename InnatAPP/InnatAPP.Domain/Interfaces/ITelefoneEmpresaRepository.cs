using System.Threading.Tasks;
using InnatAPP.Domain.Entities;
using System.Collections.Generic;

namespace InnatAPP.Domain.Interfaces
{
    public interface ITelefoneEmpresaRepository
    {
        Task<TelefoneEmpresa> BuscarTelefoneDeEmpresaPorIdAsync(int id);
        Task<IEnumerable<TelefoneEmpresa>> BuscarTelefonesDeEmpresasAsync();
        Task<IEnumerable<TelefoneEmpresa>> BuscarTelefonesPorEmpresaAsync(int idEmpresa);

        Task<TelefoneEmpresa> CriarTelefoneDeEmpresaAsync(TelefoneEmpresa telefoneEmpresa);
        Task<TelefoneEmpresa> AtualizarTelefoneDeEmpresaAsync(TelefoneEmpresa telefoneEmpresa);
        Task<TelefoneEmpresa> DeletarTelefoneDeEmpresaAsync(TelefoneEmpresa telefoneEmpresa);
    }
}
