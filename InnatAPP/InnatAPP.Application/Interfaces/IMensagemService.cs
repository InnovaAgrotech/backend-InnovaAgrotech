using InnatAPP.Application.DTOs;
using InnatAPP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnatAPP.Application.Interfaces
{
    public interface IMensagemService
    {
        Task<IEnumerable<MensagemDTO>> BuscarMensagensAsync();
        Task<MensagemDTO> BuscarMensagemPorIdAsync(int id);

        Task CriarMensagemAsync(MensagemDTO mensagemDto);
        Task AtualizarMensagemAsync(MensagemDTO mensagemDto);
        Task DeletarMensagemAsync(int id);
    }
}
