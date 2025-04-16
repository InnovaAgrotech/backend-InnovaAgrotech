using InnatAPP.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InnatAPP.Domain.Interfaces
{
    internal interface IMensagemRepository
    {
        Task<IEnumerable<Mensagem>> BuscarMensagensAsync();
        Task<Mensagem> BuscarPorIdAsync(int? id);

        Task<Mensagem> AdicionarAsync(Mensagem mensagem);

        Task<Mensagem> AtualizarAsync(Mensagem mensagem);

        Task<Mensagem> RemoverAsync(Mensagem mensagem);
    }
}
