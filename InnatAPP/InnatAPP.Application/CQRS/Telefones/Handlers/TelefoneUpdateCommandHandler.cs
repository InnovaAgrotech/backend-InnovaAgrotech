using MediatR;
using InnatAPP.Domain.Entities;
using InnatAPP.Domain.Interfaces;
using InnatAPP.Application.CQRS.Telefones.Commands;

namespace InnatAPP.Application.CQRS.Telefones.Handlers
{
    public class TelefoneUpdateCommandHandler : IRequestHandler<TelefoneUpdateCommand, Telefone>
    {
        private readonly ITelefoneRepository _telefoneRepository;
        public TelefoneUpdateCommandHandler(ITelefoneRepository telefoneRepository)
        {
            _telefoneRepository = telefoneRepository;
        }
        public async Task<Telefone> Handle(TelefoneUpdateCommand request, CancellationToken cancellationToken)
        {
            var telefone = await _telefoneRepository.BuscarTelefonePorIdAsync(request.Id);

            if (telefone == null)
            {
                throw new ApplicationException($"Entidade não pode ser encontrada.");
            }
            else
            {
                telefone.Alterar(
                    request.Ddd,
                    request.Numero
                );

                return await _telefoneRepository.AtualizarTelefoneAsync(telefone);
            }
        }
    }
}