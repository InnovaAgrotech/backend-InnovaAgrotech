namespace InnatAPP.Application.CQRS.Categorias.Commands
{
    public class CategoriaUpdateCommand : CategoriaCommand
    {
        public Guid Id { get; set; }
    }
}