using MediatR;
using InnatAPP.Domain.Entities;
using InnatAPP.Domain.Interfaces;
using InnatAPP.Application.CQRS.Telefones.Commands;

namespace InnatAPP.Application.CQRS.Telefones.Handlers
{
    public class TelefoneCreateCommandHandler : IRequestHandler<TelefoneCreateCommand, Telefone>
    {
        private readonly ITelefoneRepository _telefoneRepository;

        public TelefoneCreateCommandHandler(ITelefoneRepository telefoneRepository)
        {
            _telefoneRepository = telefoneRepository;
        }

        public async Task<Telefone> Handle(TelefoneCreateCommand request, CancellationToken cancellationToken)
        {
            var telefone = new Telefone(
                request.Ddd,
                request.Numero,
                request.IdUsuario
            );

            if (telefone == null)
            {
                throw new ApplicationException($"Erro ao criar entidade.");
            }
            else
            {
                return await _telefoneRepository.CriarTelefoneAsync(telefone);
            }
        }
    }
}