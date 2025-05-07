using AutoMapper;
using InnatAPP.Domain.Entities;
using InnatAPP.Application.DTOs;
using InnatAPP.Domain.Interfaces;
using InnatAPP.Application.Interfaces;

namespace InnatAPP.Application.Services
{
    public class EnderecoEmpresaService : IEnderecoEmpresaService
    {
        private IEnderecoEmpresaRepository _enderecoEmpresaRepository;
        private readonly IMapper _mapper;
        public EnderecoEmpresaService(IEnderecoEmpresaRepository enderecoEmpresaRepository, IMapper mapper)
        {
            _enderecoEmpresaRepository = enderecoEmpresaRepository;
            _mapper = mapper;
        }
        public async Task AtualizarEnderecoDeEmpresaAsync(EnderecoEmpresaDTO enderecoEmpresaDto)
        {
            var enderecoEmpresaEntity = _mapper.Map<EnderecoEmpresa>(enderecoEmpresaDto);
            await _enderecoEmpresaRepository.AtualizarEnderecoDeEmpresaAsync(enderecoEmpresaEntity);
        }

        public async Task<EnderecoEmpresaDTO> BuscarEnderecoDeEmpresaPorIdAsync(int id)
        {
            var enderecoEmpresaEntity = await _enderecoEmpresaRepository.BuscarEnderecoDeEmpresaPorIdAsync(id);
            return _mapper.Map<EnderecoEmpresaDTO>(enderecoEmpresaEntity);
        }

        public async Task<IEnumerable<EnderecoEmpresaDTO>> BuscarEnderecosDeEmpresasAsync()
        {
            var enderecoEmpresaEntity = await _enderecoEmpresaRepository.BuscarEnderecosDeEmpresasAsync();
            return _mapper.Map<IEnumerable<EnderecoEmpresaDTO>>(enderecoEmpresaEntity);
        }

        public async Task<IEnumerable<EnderecoEmpresaDTO>> BuscarEnderecosPorEmpresaAsync(int idEmpresa)
        {
            var enderecoEmpresaEntity = await _enderecoEmpresaRepository.BuscarEnderecosPorEmpresaAsync(idEmpresa);
            return _mapper.Map<IEnumerable<EnderecoEmpresaDTO>>(enderecoEmpresaEntity);
        }

        public async Task CriarEnderecoDeEmpresaAsync(EnderecoEmpresaDTO enderecoEmpresaDto)
        {
            var enderecoEmpresaEntity = _mapper.Map<EnderecoEmpresa>(enderecoEmpresaDto);
            await _enderecoEmpresaRepository.CriarEnderecoDeEmpresaAsync(enderecoEmpresaEntity);
        }

        public async Task DeletarEnderecoDeEmpresaAsync(int id)
        {
            var enderecoEmpresaEntity = _enderecoEmpresaRepository.BuscarEnderecoDeEmpresaPorIdAsync(id).Result;
            await _enderecoEmpresaRepository.DeletarEnderecoDeEmpresaAsync(enderecoEmpresaEntity);
        }
    }
}