using MediatR;
using InnatAPP.Domain.Entities;
using InnatAPP.Domain.Interfaces;
using InnatAPP.Domain.ValueObjects;
using InnatAPP.Application.CQRS.Usuarios.Queries;

namespace InnatAPP.Application.CQRS.Usuarios.Handlers
{
    public class GetUsuariosByTipoQueryHandler : IRequestHandler<GetUsuariosByTipoQuery, IEnumerable<Usuario>>
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public GetUsuariosByTipoQueryHandler(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
        public async Task<IEnumerable<Usuario>> Handle(GetUsuariosByTipoQuery request, CancellationToken cancellationToken)
        {
            var tipoUsuario = TipoUsuario.FromString(request.TipoUsuarioTexto);
            return await _usuarioRepository.BuscarUsuariosPorTipoAsync(tipoUsuario);
        }
    }
}