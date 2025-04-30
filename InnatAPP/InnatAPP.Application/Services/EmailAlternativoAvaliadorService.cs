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
    public class EmailAlternativoAvaliadorService : IEmailAlternativoAvaliadorService
    {
        private IEmailAlternativoAvaliadorRepository _emailAlternativoAvaliadorRepository;
        private readonly IMapper _mapper;
        public EmailAlternativoAvaliadorService(IEmailAlternativoAvaliadorRepository emailAlternativoAvaliadorRepository, IMapper mapper)
        {
            _emailAlternativoAvaliadorRepository = emailAlternativoAvaliadorRepository;
            _mapper = mapper;
        }
        public async Task AtualizarEmailAlternativoDeAvaliadorAsync(EmailAlternativoAvaliadorDTO emailAlternativoAvaliadorDto)
        {
            var emailAlternativoAvaliadorEntity = _mapper.Map<EmailAlternativoAvaliador>(emailAlternativoAvaliadorDto);
            await _emailAlternativoAvaliadorRepository.AtualizarEmailAlternativoDeAvaliadorAsync(emailAlternativoAvaliadorEntity);
        }

        public async Task<EmailAlternativoAvaliadorDTO> BuscarEmailAlternativoDeAvaliadorPorIdAsync(int id)
        {
            var emailAlternativoAvaliadorEntity = await _emailAlternativoAvaliadorRepository.BuscarEmailAlternativoDeAvaliadorPorIdAsync(id);
            return _mapper.Map<EmailAlternativoAvaliadorDTO>(emailAlternativoAvaliadorEntity);
        }

        public async Task<IEnumerable<EmailAlternativoAvaliadorDTO>> BuscarEmailsAlternativosDeAvaliadoresAsync()
        {
            var emailAlternativoAvaliadorEntity = await _emailAlternativoAvaliadorRepository.BuscarEmailsAlternativosDeAvaliadoresAsync();
            return _mapper.Map<IEnumerable<EmailAlternativoAvaliadorDTO>>(emailAlternativoAvaliadorEntity);
        }

        public async Task<IEnumerable<EmailAlternativoAvaliadorDTO>> BuscarEmailsAlternativosPorAvaliadorAsync(int idAvaliador)
        {
            var emailAlternativoAvaliadorEntity = await _emailAlternativoAvaliadorRepository.BuscarEmailsAlternativosPorAvaliadorAsync(idAvaliador);
            return _mapper.Map<IEnumerable<EmailAlternativoAvaliadorDTO>>(emailAlternativoAvaliadorEntity);
        }

        public async Task CriarEmailAlternativoDeAvaliadorAsync(EmailAlternativoAvaliadorDTO emailAlternativoAvaliadorDto)
        {
            var emailAlternativoAvaliadorEntity = _mapper.Map<EmailAlternativoAvaliador>(emailAlternativoAvaliadorDto);
            await _emailAlternativoAvaliadorRepository.CriarEmailAlternativoDeAvaliadorAsync(emailAlternativoAvaliadorEntity);
        }

        public async Task DeletarEmailAlternativoDeAvaliadorAsync(int id)
        {
            var emailAlternativoAvaliadorEntity = _emailAlternativoAvaliadorRepository.BuscarEmailAlternativoDeAvaliadorPorIdAsync(id).Result;
            await _emailAlternativoAvaliadorRepository.DeletarEmailAlternativoDeAvaliadorAsync(emailAlternativoAvaliadorEntity);
        }
    }
}
