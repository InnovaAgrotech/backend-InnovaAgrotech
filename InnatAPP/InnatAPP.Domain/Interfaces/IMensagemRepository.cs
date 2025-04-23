using System.Threading.Tasks;
using InnatAPP.Domain.Entities;
using System.Collections.Generic;

namespace InnatAPP.Domain.Interfaces
{
    public interface IMensagemRepository
    {
        Task<IEnumerable<Mensagem>> BuscarMensagensAsync();
        Task<Mensagem> BuscarMensagemPorIdAsync(int id);

        Task<Mensagem> CriarMensagemAsync(Mensagem mensagem);
        Task<Mensagem> AtualizarMensagemAsync(Mensagem mensagem);
        Task<Mensagem> DeletarMensagemAsync(Mensagem mensagem);
    }
}
