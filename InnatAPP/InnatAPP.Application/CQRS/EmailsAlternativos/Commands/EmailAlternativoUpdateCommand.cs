namespace InnatAPP.Application.CQRS.EmailsAlternativos.Commands
{
    public class EmailAlternativoUpdateCommand : EmailAlternativoCommand
    {
        public Guid Id { get; set; }
    }
}