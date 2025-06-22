using MediatR;
using InnatAPP.Domain.Entities;
using InnatAPP.Domain.Interfaces;
using InnatAPP.Application.CQRS.Enderecos.Queries;

namespace InnatAPP.Application.CQRS.Enderecos.Handlers
{
    public class GetEnderecosByUsuarioQueryHandler : IRequestHandler<GetEnderecosByUsuarioQuery, IEnumerable<Endereco>>
    {
        private readonly IEnderecoRepository _enderecoRepository;
        public GetEnderecosByUsuarioQueryHandler(IEnderecoRepository enderecoRepository)
        {
            _enderecoRepository = enderecoRepository;
        }
        public async Task<IEnumerable<Endereco>> Handle(GetEnderecosByUsuarioQuery request, CancellationToken cancellationToken)
        {
            return await _enderecoRepository.BuscarEnderecosPorUsuarioAsync(request.IdUsuario);
        }
    }
}