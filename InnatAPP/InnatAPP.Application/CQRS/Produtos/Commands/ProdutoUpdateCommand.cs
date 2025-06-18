namespace InnatAPP.Application.CQRS.Produtos.Commands
{
    public class ProdutoUpdateCommand : ProdutoCommand
    {
        public Guid Id { get; set; }
    }
}