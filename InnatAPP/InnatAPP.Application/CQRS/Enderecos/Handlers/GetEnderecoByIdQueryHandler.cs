using MediatR;
using InnatAPP.Domain.Entities;
using InnatAPP.Domain.Interfaces;
using InnatAPP.Application.CQRS.Enderecos.Queries;

namespace InnatAPP.Application.CQRS.Enderecos.Handlers
{
    public class GetEnderecoByIdQueryHandler : IRequestHandler<GetEnderecoByIdQuery, Endereco?>
    {
        private readonly IEnderecoRepository _enderecoRepository;
        public GetEnderecoByIdQueryHandler(IEnderecoRepository enderecoRepository)
        {
            _enderecoRepository = enderecoRepository;
        }
        public async Task<Endereco?> Handle(GetEnderecoByIdQuery request, CancellationToken cancellationToken)
        {
            return await _enderecoRepository.BuscarEnderecoPorIdAsync(request.Id);
        }
    }
}