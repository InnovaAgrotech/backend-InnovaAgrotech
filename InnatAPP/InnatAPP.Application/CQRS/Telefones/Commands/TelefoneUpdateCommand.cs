namespace InnatAPP.Application.CQRS.Telefones.Commands
{
    public class TelefoneUpdateCommand : TelefoneCommand
    {
        public Guid Id { get; set; }
    }
}