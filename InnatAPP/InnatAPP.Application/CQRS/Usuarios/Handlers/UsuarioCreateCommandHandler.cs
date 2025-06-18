using MediatR;
using InnatAPP.Domain.Entities;
using InnatAPP.Domain.Interfaces;
using InnatAPP.Domain.ValueObjects;
using InnatAPP.Application.CQRS.Usuarios.Commands;

namespace InnatAPP.Application.CQRS.Usuarios.Handlers
{
    public class UsuarioCreateCommandHandler : IRequestHandler<UsuarioCreateCommand, Usuario>
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioCreateCommandHandler(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<Usuario> Handle(UsuarioCreateCommand request, CancellationToken cancellationToken)
        {
            var tipoUsuario = TipoUsuario.FromString(request.TipoUsuarioTexto);

            var usuario = new Usuario(
                request.Nome,
                request.Email,
                request.SenhaHash,
                request.Foto,
                request.Biografia,
                tipoUsuario: tipoUsuario
            );

            if (usuario == null)
            {
                throw new ApplicationException($"Erro ao criar entidade.");
            }
            else
            {
                return await _usuarioRepository.CriarUsuarioAsync(usuario);
            }
        }
    }
}