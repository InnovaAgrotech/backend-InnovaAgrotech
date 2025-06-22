namespace InnatAPP.Application.CQRS.Enderecos.Commands
{
    public class EnderecoUpdateCommand : EnderecoCommand
    {
        public Guid Id { get; set; }
    }
}