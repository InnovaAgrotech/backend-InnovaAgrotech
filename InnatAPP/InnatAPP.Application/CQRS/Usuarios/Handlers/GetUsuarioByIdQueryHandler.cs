using MediatR;
using InnatAPP.Domain.Entities;
using InnatAPP.Domain.Interfaces;
using InnatAPP.Application.CQRS.Usuarios.Queries;

namespace InnatAPP.Application.CQRS.Usuarios.Handlers
{
    public class GetUsuarioByIdQueryHandler : IRequestHandler<GetUsuarioByIdQuery, Usuario?>
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public GetUsuarioByIdQueryHandler(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
        public async Task<Usuario?> Handle(GetUsuarioByIdQuery request, CancellationToken cancellationToken)
        {
            return await _usuarioRepository.BuscarUsuarioPorIdAsync(request.Id);
        }
    }
}