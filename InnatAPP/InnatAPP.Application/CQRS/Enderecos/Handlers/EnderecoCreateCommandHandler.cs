using MediatR;
using InnatAPP.Domain.Entities;
using InnatAPP.Domain.Interfaces;
using InnatAPP.Application.CQRS.Enderecos.Commands;

namespace InnatAPP.Application.CQRS.Enderecos.Handlers
{
    public class EnderecoCreateCommandHandler : IRequestHandler<EnderecoCreateCommand, Endereco>
    {
        private readonly IEnderecoRepository _enderecoRepository;

        public EnderecoCreateCommandHandler(IEnderecoRepository enderecoRepository)
        {
            _enderecoRepository = enderecoRepository;
        }

        public async Task<Endereco> Handle(EnderecoCreateCommand request, CancellationToken cancellationToken)
        {
            var endereco = new Endereco(
                request.Numero,
                request.Rua,
                request.Bairro,
                request.Cidade,
                request.Estado,
                request.Complemento,
                request.Cep,
                request.IdUsuario
            );

            if (endereco == null)
            {
                throw new ApplicationException($"Erro ao criar entidade.");
            }
            else
            {
                return await _enderecoRepository.CriarEnderecoAsync(endereco);
            }
        }
    }
}