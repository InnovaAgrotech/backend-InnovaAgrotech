using InnatAPP.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InnatAPP.Domain.Interfaces
{
    internal interface IAvaliadorRepository
    {
        Task<IEnumerable<Avaliador>> BuscarAvaliadoresAsync();
        Task<Avaliador> BuscarPorIdAsync(int? id);

        Task<Avaliador> BuscarAvaliadorReviewAsync(int? id);

        Task<Avaliador> AdicionarAsync(Avaliador avaliador);

        Task<Avaliador> AtualizarAsync(Avaliador avaliador);

        Task<Avaliador> RemoverAsync(Avaliador avaliador);
    }
}
