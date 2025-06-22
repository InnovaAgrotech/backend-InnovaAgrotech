using MediatR;
using InnatAPP.Domain.Entities;
using InnatAPP.Domain.Interfaces;
using InnatAPP.Application.CQRS.Enderecos.Commands;

namespace InnatAPP.Application.CQRS.Enderecos.Handlers
{
    public class EnderecoRemoveCommandHandler : IRequestHandler<EnderecoRemoveCommand, Endereco>
    {
        private readonly IEnderecoRepository _enderecoRepository;
        public EnderecoRemoveCommandHandler(IEnderecoRepository enderecoRepository)
        {
            _enderecoRepository = enderecoRepository;
        }
        public async Task<Endereco> Handle(EnderecoRemoveCommand request, CancellationToken cancellationToken)
        {
            var endereco = await _enderecoRepository.BuscarEnderecoPorIdAsync(request.Id);

            if (endereco == null)
            {
                throw new ApplicationException($"Entidade não pode ser encontrada.");
            }
            else
            {
                var resultado = await _enderecoRepository.DeletarEnderecoAsync(endereco);
                return resultado;
            }
        }
    }
}