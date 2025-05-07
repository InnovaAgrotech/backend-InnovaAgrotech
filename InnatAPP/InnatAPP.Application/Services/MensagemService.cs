using AutoMapper;
using InnatAPP.Domain.Entities;
using InnatAPP.Application.DTOs;
using InnatAPP.Domain.Interfaces;
using InnatAPP.Application.Interfaces;

namespace InnatAPP.Application.Services
{
    public class MensagemService : IMensagemService
    {
        private IMensagemRepository _mensagemRepository;
        private readonly IMapper _mapper;
        public MensagemService(IMensagemRepository mensagemRepository, IMapper mapper)
        {
            _mensagemRepository = mensagemRepository;
            _mapper = mapper;
        }
        public async Task AtualizarMensagemAsync(MensagemDTO mensagemDto)
        {
            var mensagemEntity = _mapper.Map<Mensagem>(mensagemDto);
            await _mensagemRepository.AtualizarMensagemAsync(mensagemEntity);
        }

        public async Task<MensagemDTO> BuscarMensagemPorIdAsync(int id)
        {
            var mensagemEntity = await _mensagemRepository.BuscarMensagemPorIdAsync(id);
            return _mapper.Map<MensagemDTO>(mensagemEntity);
        }

        public async Task<IEnumerable<MensagemDTO>> BuscarMensagensAsync()
        {
            var mensagemEntity = await _mensagemRepository.BuscarMensagensAsync();
            return _mapper.Map<IEnumerable<MensagemDTO>>(mensagemEntity);
        }

        public async Task CriarMensagemAsync(MensagemDTO mensagemDto)
        {
            var mensagemEntity = _mapper.Map<Mensagem>(mensagemDto);
            await _mensagemRepository.CriarMensagemAsync(mensagemEntity);
        }

        public async Task DeletarMensagemAsync(int id)
        {
            var mensagemEntity = _mensagemRepository.BuscarMensagemPorIdAsync(id).Result;
            await _mensagemRepository.DeletarMensagemAsync(mensagemEntity);
        }
    }
}