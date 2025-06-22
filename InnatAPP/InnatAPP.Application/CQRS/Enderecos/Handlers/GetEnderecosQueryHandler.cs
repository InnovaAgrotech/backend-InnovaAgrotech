using MediatR;
using InnatAPP.Domain.Entities;
using InnatAPP.Domain.Interfaces;
using InnatAPP.Application.CQRS.Enderecos.Queries;

namespace InnatAPP.Application.CQRS.Enderecos.Handlers
{
    public class GetEnderecosQueryHandler : IRequestHandler<GetEnderecosQuery, IEnumerable<Endereco>>
    {
        private readonly IEnderecoRepository _enderecoRepository;
        public GetEnderecosQueryHandler(IEnderecoRepository enderecoRepository)
        {
            _enderecoRepository = enderecoRepository;
        }
        public async Task<IEnumerable<Endereco>> Handle(GetEnderecosQuery request, CancellationToken cancellationToken)
        {
            return await _enderecoRepository.BuscarEnderecosAsync();
        }
    }
}