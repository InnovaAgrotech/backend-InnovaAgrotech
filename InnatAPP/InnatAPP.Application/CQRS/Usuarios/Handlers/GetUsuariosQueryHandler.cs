using MediatR;
using InnatAPP.Domain.Entities;
using InnatAPP.Domain.Interfaces;
using InnatAPP.Application.CQRS.Usuarios.Queries;

namespace InnatAPP.Application.CQRS.Usuarios.Handlers
{
    public class GetUsuariosQueryHandler : IRequestHandler<GetUsuariosQuery, IEnumerable<Usuario>>
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public GetUsuariosQueryHandler(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
        public async Task<IEnumerable<Usuario>> Handle(GetUsuariosQuery request, CancellationToken cancellationToken)
        {
            return await _usuarioRepository.BuscarUsuariosAsync();
        }
    }
}