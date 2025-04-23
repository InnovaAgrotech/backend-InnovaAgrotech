using System.Threading.Tasks;
using InnatAPP.Domain.Entities;
using System.Collections.Generic;

namespace InnatAPP.Domain.Interfaces
{
    public interface IAvaliadorRepository
    {
        Task<IEnumerable<Avaliador>> BuscarAvaliadoresAsync();
        Task<Avaliador> BuscarAvaliadorPorIdAsync(int id);

        Task<Avaliador> CriarAvaliadorAsync(Avaliador avaliador);
        Task<Avaliador> AtualizarAvaliadorAsync(Avaliador avaliador);
        Task<Avaliador> DeletarAvaliadorAsync(Avaliador avaliador);
    }
}
