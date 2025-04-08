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

        Task<Avaliador> AdicionarAsync(Review review);

        Task<Avaliador> AtualizarAsync(Review review);

        Task<Avaliador> RemoverAsync(Review review);
    }
}
