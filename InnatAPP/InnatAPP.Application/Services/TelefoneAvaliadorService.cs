using AutoMapper;
using InnatAPP.Domain.Entities;
using InnatAPP.Application.DTOs;
using InnatAPP.Domain.Interfaces;
using InnatAPP.Application.Interfaces;

namespace InnatAPP.Application.Services
{
    public class TelefoneAvaliadorService : ITelefoneAvaliadorService
    {
        private ITelefoneAvaliadorRepository _telefoneAvaliadorRepository;
        private readonly IMapper _mapper;
        public TelefoneAvaliadorService(ITelefoneAvaliadorRepository telefoneAvaliadorRepository, IMapper mapper)
        {
            _telefoneAvaliadorRepository = telefoneAvaliadorRepository;
            _mapper = mapper;
        }
        public async Task AtualizarTelefoneDeAvaliadorAsync(TelefoneAvaliadorDTO telefoneAvaliadorDto)
        {
            var telefoneAvaliadorEntity = _mapper.Map<TelefoneAvaliador>(telefoneAvaliadorDto);
            await _telefoneAvaliadorRepository.AtualizarTelefoneDeAvaliadorAsync(telefoneAvaliadorEntity);
        }

        public async Task<TelefoneAvaliadorDTO> BuscarTelefoneDeAvaliadorPorIdAsync(int id)
        {
            var telefoneAvaliadorEntity = await _telefoneAvaliadorRepository.BuscarTelefoneDeAvaliadorPorIdAsync(id);
            return _mapper.Map<TelefoneAvaliadorDTO>(telefoneAvaliadorEntity);
        }

        public async Task<IEnumerable<TelefoneAvaliadorDTO>> BuscarTelefonesDeAvaliadoresAsync()
        {
            var telefoneAvaliadorEntity = await _telefoneAvaliadorRepository.BuscarTelefonesDeAvaliadoresAsync();
            return _mapper.Map<IEnumerable<TelefoneAvaliadorDTO>>(telefoneAvaliadorEntity);
        }

        public async Task<IEnumerable<TelefoneAvaliadorDTO>> BuscarTelefonesPorAvaliadorAsync(int idAvaliador)
        {
            var telefoneAvaliadorEntity = await _telefoneAvaliadorRepository.BuscarTelefonesPorAvaliadorAsync(idAvaliador);
            return _mapper.Map<IEnumerable<TelefoneAvaliadorDTO>>(telefoneAvaliadorEntity);
        }

        public async Task CriarTelefoneDeAvaliadorAsync(TelefoneAvaliadorDTO telefoneAvaliadorDto)
        {
            var telefoneAvaliadorEntity = _mapper.Map<TelefoneAvaliador>(telefoneAvaliadorDto);
            await _telefoneAvaliadorRepository.CriarTelefoneDeAvaliadorAsync(telefoneAvaliadorEntity);
        }

        public async Task DeletarTelefoneDeAvaliadorAsync(int id)
        {
            var telefoneAvaliadorEntity = _telefoneAvaliadorRepository.BuscarTelefoneDeAvaliadorPorIdAsync(id).Result;
            await _telefoneAvaliadorRepository.DeletarTelefoneDeAvaliadorAsync(telefoneAvaliadorEntity);
        }
    }
}