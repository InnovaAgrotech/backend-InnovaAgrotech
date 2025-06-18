using MediatR;
using InnatAPP.Domain.Entities;
using InnatAPP.Domain.Interfaces;
using InnatAPP.Application.CQRS.Usuarios.Queries;

namespace InnatAPP.Application.CQRS.Usuarios.Handlers
{
    public class GetUsuarioByEmailQueryHandler : IRequestHandler<GetUsuarioByEmailQuery, Usuario?>
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public GetUsuarioByEmailQueryHandler(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
        public async Task<Usuario?> Handle(GetUsuarioByEmailQuery request, CancellationToken cancellationToken)
        {
            return await _usuarioRepository.BuscarUsuarioPorEmailAsync(request.Email);
        }
    }
}