using MediatR;
using InnatAPP.Domain.Entities;
using InnatAPP.Domain.Interfaces;
using InnatAPP.Application.CQRS.Categorias.Commands;

namespace InnatAPP.Application.CQRS.Categorias.Handlers
{
    public class CategoriaCreateCommandHandler : IRequestHandler<CategoriaCreateCommand, Categoria>
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaCreateCommandHandler(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public async Task<Categoria> Handle(CategoriaCreateCommand request, CancellationToken cancellationToken)
        {
            var categoria = new Categoria(
                request.Nome
            );

            if (categoria == null)
            {
                throw new ApplicationException($"Erro ao criar entidade.");
            }
            else
            {
                return await _categoriaRepository.CriarCategoriaAsync(categoria);
            }
        }
    }
}