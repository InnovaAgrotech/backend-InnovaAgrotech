using MediatR;
using InnatAPP.Domain.Entities;
using InnatAPP.Domain.Interfaces;
using InnatAPP.Application.CQRS.Usuarios.Queries;

namespace InnatAPP.Application.CQRS.Usuarios.Handlers
{
    public class GetUsuarioByEmailESenhaQueryHandler : IRequestHandler<GetUsuarioByEmailESenhaQuery, Usuario?>
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public GetUsuarioByEmailESenhaQueryHandler(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
        public async Task<Usuario?> Handle(GetUsuarioByEmailESenhaQuery request, CancellationToken cancellationToken)
        {
            return await _usuarioRepository.BuscarUsuarioPorEmailESenhaAsync(request.Email, request.SenhaHash);
        }
    }
}