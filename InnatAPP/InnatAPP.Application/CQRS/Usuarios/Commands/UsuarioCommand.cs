using MediatR;
using InnatAPP.Domain.Entities;

namespace InnatAPP.Application.CQRS.Usuarios.Commands
{
    public abstract class UsuarioCommand : IRequest<Usuario>
    {
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string SenhaHash { get; set; } = string.Empty;
        public string Foto { get; set; } = string.Empty;
        public string Biografia { get; set; } = string.Empty;
        public string TipoUsuarioTexto { get; set; } = string.Empty;
    }
}