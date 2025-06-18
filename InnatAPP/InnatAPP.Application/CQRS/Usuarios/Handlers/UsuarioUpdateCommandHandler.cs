using MediatR;
using InnatAPP.Domain.Entities;
using InnatAPP.Domain.Interfaces;
using InnatAPP.Application.CQRS.Usuarios.Commands;

namespace InnatAPP.Application.CQRS.Usuarios.Handlers
{
    public class UsuarioUpdateCommandHandler : IRequestHandler<UsuarioUpdateCommand, Usuario>
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public UsuarioUpdateCommandHandler(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
        public async Task<Usuario> Handle(UsuarioUpdateCommand request, CancellationToken cancellationToken)
        {
            var usuario = await _usuarioRepository.BuscarUsuarioPorIdAsync(request.Id);

            if (usuario == null)
            {
                throw new ApplicationException($"Entidade não pode ser encontrada.");
            }
            else
            {
                usuario.Alterar(request.Nome, request.Email, request.SenhaHash, request.Foto, request.Biografia);
                return await _usuarioRepository.AtualizarUsuarioAsync(usuario);
            }
        }
    }
}