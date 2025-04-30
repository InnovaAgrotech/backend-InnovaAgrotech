using AutoMapper;
using InnatAPP.Application.DTOs;
using InnatAPP.Application.Interfaces;
using InnatAPP.Domain.Entities;
using InnatAPP.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnatAPP.Application.Services
{
    public class AvaliadorService : IAvaliadorService
    {
    private IAvaliadorRepository _avaliadorRepository;
    private readonly IMapper _mapper;
    public AvaliadorService(IAvaliadorRepository avaliadorRepository, IMapper mapper)
    {
        _avaliadorRepository = avaliadorRepository;
        _mapper = mapper;
    }
        public async Task AtualizarAvaliadorAsync(AvaliadorDTO avaliadorDto)
        {
            var avaliadorEntity = _mapper.Map<Avaliador>(avaliadorDto);
            await _avaliadorRepository.AtualizarAvaliadorAsync(avaliadorEntity);
        }

        public async Task<IEnumerable<AvaliadorDTO>> BuscarAvaliadoresAsync()
        {
            var avaliadorEntity = await _avaliadorRepository.BuscarAvaliadoresAsync();
            return _mapper.Map<IEnumerable<AvaliadorDTO>>(avaliadorEntity);
        }

        public async Task<AvaliadorDTO> BuscarAvaliadorPorIdAsync(int id)
        {
            var avaliadorEntity = await _avaliadorRepository.BuscarAvaliadorPorIdAsync(id);
            return _mapper.Map<AvaliadorDTO>(avaliadorEntity);
        }

        public async Task CriarAvaliadorAsync(AvaliadorDTO avaliadorDto)
        {
            var avaliadorEntity = _mapper.Map<Avaliador>(avaliadorDto);
            await _avaliadorRepository.CriarAvaliadorAsync(avaliadorEntity);
        }

        public async Task DeletarAvaliadorAsync(int id)
        {
            var avaliadorEntity = _avaliadorRepository.BuscarAvaliadorPorIdAsync(id).Result;
            await _avaliadorRepository.DeletarAvaliadorAsync(avaliadorEntity);
        }
    }
}
