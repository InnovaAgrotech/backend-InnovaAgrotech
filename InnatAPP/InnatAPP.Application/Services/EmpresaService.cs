using AutoMapper;
using InnatAPP.Domain.Entities;
using InnatAPP.Application.DTOs;
using InnatAPP.Domain.Interfaces;
using InnatAPP.Application.Interfaces;

namespace InnatAPP.Application.Services
{
    public class EmpresaService : IEmpresaService
    {
        private IEmpresaRepository _empresaRepository;
        private readonly IMapper _mapper;
        public EmpresaService(IEmpresaRepository empresaRepository, IMapper mapper)
        {
            _empresaRepository = empresaRepository;
            _mapper = mapper;
        }
        public async Task AtualizarEmpresaAsync(EmpresaDTO empresaDto)
        {
            var empresaEntity = _mapper.Map<Empresa>(empresaDto);
            await _empresaRepository.AtualizarEmpresaAsync(empresaEntity);
        }

        public async Task<EmpresaDTO> BuscarEmpresaPorIdAsync(int id)
        {
            var empresaEntity = await _empresaRepository.BuscarEmpresaPorIdAsync(id);
            return _mapper.Map<EmpresaDTO>(empresaEntity);
        }

        public async Task<IEnumerable<EmpresaDTO>> BuscarEmpresasAsync()
        {
            var empresaEntity = await _empresaRepository.BuscarEmpresasAsync();
            return _mapper.Map<IEnumerable<EmpresaDTO>>(empresaEntity);
        }

        public async Task CriarEmpresaAsync(EmpresaDTO empresaDto)
        {
            var empresaEntity = _mapper.Map<Empresa>(empresaDto);
            await _empresaRepository.CriarEmpresaAsync(empresaEntity);
        }

        public async Task DeletarEmpresaAsync(int id)
        {
            var empresaEntity = _empresaRepository.BuscarEmpresaPorIdAsync(id).Result;
            await _empresaRepository.DeletarEmpresaAsync(empresaEntity);
        }
    }
}