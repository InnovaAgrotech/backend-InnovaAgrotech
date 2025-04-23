using System.Threading.Tasks;
using InnatAPP.Domain.Entities;
using System.Collections.Generic;

namespace InnatAPP.Domain.Interfaces
{
    public interface ITelefoneAvaliadorRepository
    {
        Task<TelefoneAvaliador> BuscarTelefoneDeAvaliadorPorIdAsync(int id);
        Task<IEnumerable<TelefoneAvaliador>> BuscarTelefonesDeAvaliadoresAsync();
        Task<IEnumerable<TelefoneAvaliador>> BuscarTelefonesPorAvaliadorAsync(int idAvaliador);

        Task<TelefoneAvaliador> CriarTelefoneDeAvaliadorAsync(TelefoneAvaliador telefoneAvaliador);
        Task<TelefoneAvaliador> AtualizarTelefoneDeAvaliadorAsync(TelefoneAvaliador telefoneAvaliador);
        Task<TelefoneAvaliador> DeletarTelefoneDeAvaliadorAsync(TelefoneAvaliador telefoneAvaliador);
    }
}
