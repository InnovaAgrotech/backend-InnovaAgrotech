using InnatAPP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnatAPP.Domain.Interfaces
{
    internal interface ITelefoneRepository
    {
        Task<IEnumerable<Telefone>> BuscarTelefonesAsync();
        Task<Telefone> BuscarPorIdAsync(int? id);

        Task<Telefone> AdicionarAsync(Telefone telefone);

        Task<Telefone> AtualizarAsync(Telefone telefone);

        Task<Telefone> RemoverAsync(Telefone telefone);
    }
}
