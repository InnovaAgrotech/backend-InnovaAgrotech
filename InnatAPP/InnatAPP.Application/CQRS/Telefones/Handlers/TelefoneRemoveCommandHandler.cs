using InnatAPP.Application.CQRS.Telefones.Commands;
using InnatAPP.Domain.Entities;
using InnatAPP.Domain.Interfaces;
using MediatR;

namespace InnatAPP.Application.CQRS.Telefones.Handlers
{
    public class TelefoneRemoveCommandHandler : IRequestHandler<TelefoneRemoveCommand, Telefone>
    {
        private readonly ITelefoneRepository _telefoneRepository;
        public TelefoneRemoveCommandHandler(ITelefoneRepository telefoneRepository)
        {
            _telefoneRepository = telefoneRepository;
        }
        public async Task<Telefone> Handle(TelefoneRemoveCommand request, CancellationToken cancellationToken)
        {
            var telefone = await _telefoneRepository.BuscarTelefonePorIdAsync(request.Id);

            if (telefone == null)
            {
                throw new ApplicationException($"Entidade não pode ser encontrada.");
            }
            else
            {
                var resultado = await _telefoneRepository.DeletarTelefoneAsync(telefone);
                return resultado;
            }
        }
    }
}