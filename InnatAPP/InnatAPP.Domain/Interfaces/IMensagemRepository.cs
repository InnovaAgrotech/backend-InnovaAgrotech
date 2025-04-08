using InnatAPP.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InnatAPP.Domain.Interfaces
{
    internal interface IMensagemRepository
    {
        Task<IEnumerable<Mensagem>> BuscarMensagensAsync();
        Task<Mensagem> BuscarPorIdAsync(int? id);

        Task<Mensagem> AdicionarAsync(Produto produto);

        Task<Mensagem> AtualizarAsync(Produto produto);

        Task<Mensagem> RemoverAsync(Produto produto);
    }
}
