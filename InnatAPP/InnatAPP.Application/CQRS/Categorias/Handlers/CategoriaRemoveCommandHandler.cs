using MediatR;
using InnatAPP.Domain.Entities;
using InnatAPP.Domain.Interfaces;
using InnatAPP.Application.CQRS.Categorias.Commands;

namespace InnatAPP.Application.CQRS.Categorias.Handlers
{
    public class CategoriaRemoveCommandHandler : IRequestHandler<CategoriaRemoveCommand, Categoria>
    {
        private readonly ICategoriaRepository _categoriaRepository;
        public CategoriaRemoveCommandHandler(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }
        public async Task<Categoria> Handle(CategoriaRemoveCommand request, CancellationToken cancellationToken)
        {
            var categoria = await _categoriaRepository.BuscarCategoriaPorIdAsync(request.Id);

            if (categoria == null)
            {
                throw new ApplicationException($"Entidade não pode ser encontrada.");
            }
            else
            {
                var resultado = await _categoriaRepository.DeletarCategoriaAsync(categoria);
                return resultado;
            }
        }
    }
}