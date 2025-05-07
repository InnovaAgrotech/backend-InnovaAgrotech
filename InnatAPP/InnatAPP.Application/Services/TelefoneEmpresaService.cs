using AutoMapper;
using InnatAPP.Domain.Entities;
using InnatAPP.Application.DTOs;
using InnatAPP.Domain.Interfaces;
using InnatAPP.Application.Interfaces;

namespace InnatAPP.Application.Services
{
    public class TelefoneEmpresaService : ITelefoneEmpresaService
    {
        private ITelefoneEmpresaRepository _telefoneEmpresaRepository;
        private readonly IMapper _mapper;
        public TelefoneEmpresaService(ITelefoneEmpresaRepository telefoneEmpresaRepository, IMapper mapper)
        {
            _telefoneEmpresaRepository = telefoneEmpresaRepository;
            _mapper = mapper;
        }
        public async Task AtualizarTelefoneDeEmpresaAsync(TelefoneEmpresaDTO telefoneEmpresaDto)
        {
            var telefoneEmpresaEntity = _mapper.Map<TelefoneEmpresa>(telefoneEmpresaDto);
            await _telefoneEmpresaRepository.AtualizarTelefoneDeEmpresaAsync(telefoneEmpresaEntity);
        }

        public async Task<TelefoneEmpresaDTO> BuscarTelefoneDeEmpresaPorIdAsync(int id)
        {
            var telefoneEmpresaEntity = await _telefoneEmpresaRepository.BuscarTelefoneDeEmpresaPorIdAsync(id);
            return _mapper.Map<TelefoneEmpresaDTO>(telefoneEmpresaEntity);
        }

        public async Task<IEnumerable<TelefoneEmpresaDTO>> BuscarTelefonesDeEmpresasAsync()
        {
            var telefoneEmpresaEntity = await _telefoneEmpresaRepository.BuscarTelefonesDeEmpresasAsync();
            return _mapper.Map<IEnumerable<TelefoneEmpresaDTO>>(telefoneEmpresaEntity);
        }

        public async Task<IEnumerable<TelefoneEmpresaDTO>> BuscarTelefonesPorEmpresaAsync(int idEmpresa)
        {
            var telefoneEmpresaEntity = await _telefoneEmpresaRepository.BuscarTelefonesPorEmpresaAsync(idEmpresa);
            return _mapper.Map<IEnumerable<TelefoneEmpresaDTO>>(telefoneEmpresaEntity);
        }

        public async Task CriarTelefoneDeEmpresaAsync(TelefoneEmpresaDTO telefoneEmpresaDto)
        {
            var telefoneEmpresaEntity = _mapper.Map<TelefoneEmpresa>(telefoneEmpresaDto);
            await _telefoneEmpresaRepository.CriarTelefoneDeEmpresaAsync(telefoneEmpresaEntity);
        }

        public async Task DeletarTelefoneDeEmpresaAsync(int id)
        {
            var telefoneEmpresaEntity = _telefoneEmpresaRepository.BuscarTelefoneDeEmpresaPorIdAsync(id).Result;
            await _telefoneEmpresaRepository.DeletarTelefoneDeEmpresaAsync(telefoneEmpresaEntity);
        }
    }
}