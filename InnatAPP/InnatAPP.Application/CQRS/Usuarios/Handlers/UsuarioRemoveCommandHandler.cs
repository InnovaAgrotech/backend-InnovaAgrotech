using MediatR;
using InnatAPP.Domain.Entities;
using InnatAPP.Domain.Interfaces;
using InnatAPP.Application.CQRS.Usuarios.Commands;

namespace InnatAPP.Application.CQRS.Usuarios.Handlers
{
    public class UsuarioRemoveCommandHandler : IRequestHandler<UsuarioRemoveCommand, Usuario>
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public UsuarioRemoveCommandHandler(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
        public async Task<Usuario> Handle(UsuarioRemoveCommand request, CancellationToken cancellationToken)
        {
            var usuario = await _usuarioRepository.BuscarUsuarioPorIdAsync(request.Id);

            if (usuario == null)
            {
                throw new ApplicationException($"Entidade não pode ser encontrada.");
            }
            else
            {
                var resultado = await _usuarioRepository.DeletarUsuarioAsync(usuario);
                return resultado;
            }
        }
    }
}