using MediatR;
using InnatAPP.Domain.Entities;
using InnatAPP.Domain.Interfaces;
using InnatAPP.Application.CQRS.Enderecos.Commands;

namespace InnatAPP.Application.CQRS.Enderecos.Handlers
{
    public class EnderecoUpdateCommandHandler : IRequestHandler<EnderecoUpdateCommand, Endereco>
    {
        private readonly IEnderecoRepository _enderecoRepository;
        public EnderecoUpdateCommandHandler(IEnderecoRepository enderecoRepository)
        {
            _enderecoRepository = enderecoRepository;
        }
        public async Task<Endereco> Handle(EnderecoUpdateCommand request, CancellationToken cancellationToken)
        {
            var endereco = await _enderecoRepository.BuscarEnderecoPorIdAsync(request.Id);

            if (endereco == null)
            {
                throw new ApplicationException($"Entidade não pode ser encontrada.");
            }
            else
            {
                endereco.Alterar(
                    request.Numero,
                    request.Rua,
                    request.Bairro,
                    request.Cidade,
                    request.Estado,
                    request.Complemento,
                    request.Cep
                );

                return await _enderecoRepository.AtualizarEnderecoAsync(endereco);
            }
        }
    }
}