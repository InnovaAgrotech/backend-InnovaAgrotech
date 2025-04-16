using InnatAPP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnatAPP.Domain.Interfaces
{
    internal interface IEnderecoRepository
    {
        Task<IEnumerable<Endereco>> BuscarEnderecosAsync();
        Task<Endereco> BuscarPorIdAsync(int? id);

        Task<Endereco> AdicionarAsync(Endereco endereco);

        Task<Endereco> AtualizarAsync(Endereco endereco);

        Task<Endereco> RemoverAsync(Endereco endereco);
    }
}
