using AutoMapper;
using InnatAPP.Domain.Entities;
using InnatAPP.Application.DTOs;
using InnatAPP.Domain.Interfaces;
using InnatAPP.Application.Interfaces;

namespace InnatAPP.Application.Services
{
    public class EnderecoAvaliadorService : IEnderecoAvaliadorService
    {
        private IEnderecoAvaliadorRepository _enderecoAvaliadorRepository;
        private readonly IMapper _mapper;
        public EnderecoAvaliadorService(IEnderecoAvaliadorRepository enderecoAvaliadorRepository, IMapper mapper)
        {
            _enderecoAvaliadorRepository = enderecoAvaliadorRepository;
            _mapper = mapper;
        }
        public async Task AtualizarEnderecoDeAvaliadorAsync(EnderecoAvaliadorDTO enderecoAvaliadorDto)
        {
            var enderecoAvaliadorEntity = _mapper.Map<EnderecoAvaliador>(enderecoAvaliadorDto);
            await _enderecoAvaliadorRepository.AtualizarEnderecoDeAvaliadorAsync(enderecoAvaliadorEntity);
        }

        public async Task<EnderecoAvaliadorDTO> BuscarEnderecoDeAvaliadorPorIdAsync(int id)
        {
            var enderecoAvaliadorEntity = await _enderecoAvaliadorRepository.BuscarEnderecoDeAvaliadorPorIdAsync(id);
            return _mapper.Map<EnderecoAvaliadorDTO>(enderecoAvaliadorEntity);
        }

        public async Task<IEnumerable<EnderecoAvaliadorDTO>> BuscarEnderecosDeAvaliadoresAsync()
        {
            var enderecoAvaliadorEntity = await _enderecoAvaliadorRepository.BuscarEnderecosDeAvaliadoresAsync();
            return _mapper.Map<IEnumerable<EnderecoAvaliadorDTO>>(enderecoAvaliadorEntity);
        }

        public async Task<IEnumerable<EnderecoAvaliadorDTO>> BuscarEnderecosPorAvaliadorAsync(int idAvaliador)
        {
            var enderecoAvaliadorEntity = await _enderecoAvaliadorRepository.BuscarEnderecosPorAvaliadorAsync(idAvaliador);
            return _mapper.Map<IEnumerable<EnderecoAvaliadorDTO>>(enderecoAvaliadorEntity);
        }

        public async Task CriarEnderecoDeAvaliadorAsync(EnderecoAvaliadorDTO enderecoAvaliadorDto)
        {
            var enderecoAvaliadorEntity = _mapper.Map<EnderecoAvaliador>(enderecoAvaliadorDto);
            await _enderecoAvaliadorRepository.CriarEnderecoDeAvaliadorAsync(enderecoAvaliadorEntity);
        }

        public async Task DeletarEnderecoDeAvaliadorAsync(int id)
        {
            var enderecoAvaliadorEntity = _enderecoAvaliadorRepository.BuscarEnderecoDeAvaliadorPorIdAsync(id).Result;
            await _enderecoAvaliadorRepository.DeletarEnderecoDeAvaliadorAsync(enderecoAvaliadorEntity); 
        }
    }
}