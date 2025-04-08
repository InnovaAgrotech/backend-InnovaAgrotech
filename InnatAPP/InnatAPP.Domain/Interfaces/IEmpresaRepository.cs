using InnatAPP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnatAPP.Domain.Interfaces
{
    internal interface IEmpresaRepository
    {
        Task<IEnumerable<Empresa>> BuscarEmpresasAsync();
        Task<Empresa> BuscarPorIdAsync(int? id);

        Task<Empresa> BuscarEmpresaProdutoAsync(int? id);

        Task<Empresa> AdicionarAsync(Empresa empresa);

        Task<Empresa> AtualizarAsync(Empresa empresa);

        Task<Empresa> RemoverAsync(Empresa empresa);
    }
}
