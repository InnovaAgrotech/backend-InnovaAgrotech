using MediatR;
using InnatAPP.Domain.Entities;
using InnatAPP.Domain.Interfaces;
using InnatAPP.Application.CQRS.Categorias.Commands;

namespace InnatAPP.Application.CQRS.Categorias.Handlers
{
    public class CategoriaUpdateCommandHandler : IRequestHandler<CategoriaUpdateCommand, Categoria>
    {
        private readonly ICategoriaRepository _categoriaRepository;
        public CategoriaUpdateCommandHandler(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }
        public async Task<Categoria> Handle(CategoriaUpdateCommand request, CancellationToken cancellationToken)
        {
            var categoria = await _categoriaRepository.BuscarCategoriaPorIdAsync(request.Id);

            if (categoria == null)
            {
                throw new ApplicationException($"Entidade não pode ser encontrada.");
            }
            else
            {
                categoria.Alterar(
                    request.Nome
                );

                return await _categoriaRepository.AtualizarCategoriaAsync(categoria);
            }
        }
    }
}