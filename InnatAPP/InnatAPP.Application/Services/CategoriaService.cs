using AutoMapper;
using InnatAPP.Domain.Entities;
using InnatAPP.Application.DTOs;
using InnatAPP.Domain.Interfaces;
using InnatAPP.Application.Interfaces;

namespace InnatAPP.Application.Services
{
    public class CategoriaService : ICategoriaService
    {
        private ICategoriaRepository _categoriaRepository;
        private readonly IMapper _mapper;

        public CategoriaService(ICategoriaRepository categoriaRepository, IMapper mapper)
        {
            _categoriaRepository = categoriaRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoriaDTO>> BuscarCategoriasAsync()
        {
            var categoriasEntity = await _categoriaRepository.BuscarCategoriasAsync();
            return _mapper.Map<IEnumerable<CategoriaDTO>>(categoriasEntity);
        }

        public async Task<CategoriaDTO> BuscarCategoriaPorIdAsync(int id)
        {
            var categoriaEntity = await _categoriaRepository.BuscarCategoriaPorIdAsync(id);
            return _mapper.Map<CategoriaDTO>(categoriaEntity);
        }

        public async Task CriarCategoriaAsync(CategoriaDTO categoriaDto)
        {
            var categoriaEntity = _mapper.Map<Categoria>(categoriaDto);
            await _categoriaRepository.CriarCategoriaAsync(categoriaEntity);
        }

        public async Task AtualizarCategoriaAsync(CategoriaDTO categoriaDto)
        {
            var categoriaEntity = _mapper.Map<Categoria>(categoriaDto);
            await _categoriaRepository.AtualizarCategoriaAsync(categoriaEntity);
        }

        public async Task DeletarCategoriaAsync(int id)
        {
            var categoriaEntity = _categoriaRepository.BuscarCategoriaPorIdAsync(id).Result;
            await _categoriaRepository.DeletarCategoriaAsync(categoriaEntity);
        }
    }
}