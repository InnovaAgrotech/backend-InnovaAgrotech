namespace InnatAPP.Application.CQRS.Usuarios.Commands
{
    public class UsuarioUpdateCommand : UsuarioCommand
    {
        public Guid Id { get; set; }
    }
}