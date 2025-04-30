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
    class EmailAlternativoEmpresaService : IEmailAlternativoEmpresaService
    {
        private IEmailAlternativoEmpresaRepository _emailAlternativoEmpresaRepository;
        private readonly IMapper _mapper;
        public EmailAlternativoEmpresaService(IEmailAlternativoEmpresaRepository emailAlternativoEmpresaRepository, IMapper mapper)
        {
            _emailAlternativoEmpresaRepository = emailAlternativoEmpresaRepository;
            _mapper = mapper;
        }
        public async Task AtualizarEmailAlternativoEmpresaAsync(EmailAlternativoEmpresaDTO emailAlternativoEmpresaDto)
        {
            var emailAlternativoEmpresaEntity = _mapper.Map<EmailAlternativoEmpresa>(emailAlternativoEmpresaDto);
            await _emailAlternativoEmpresaRepository.AtualizarEmailAlternativoEmpresaAsync(emailAlternativoEmpresaEntity);
        }

        public async Task<EmailAlternativoEmpresaDTO> BuscarEmailAlternativoDeEmpresaPorIdAsync(int id)
        {
            var emailAlternativoEmpresaEntity = await _emailAlternativoEmpresaRepository.BuscarEmailAlternativoDeEmpresaPorIdAsync(id);
            return _mapper.Map<EmailAlternativoEmpresaDTO>(emailAlternativoEmpresaEntity);
        }

        public async Task<IEnumerable<EmailAlternativoEmpresaDTO>> BuscarEmailsAlternativosDeEmpresasAsync()
        {
            var emailAlternativoEmpresaEntity = await _emailAlternativoEmpresaRepository.BuscarEmailsAlternativosDeEmpresasAsync();
            return _mapper.Map<IEnumerable<EmailAlternativoEmpresaDTO>>(emailAlternativoEmpresaEntity);
        }

        public async Task<IEnumerable<EmailAlternativoEmpresaDTO>> BuscarEmailsAlternativosPorEmpresaAsync(int idEmpresa)
        {
            var emailAlternativoEmpresaEntity = await _emailAlternativoEmpresaRepository.BuscarEmailsAlternativosPorEmpresaAsync(idEmpresa);
            return _mapper.Map<IEnumerable<EmailAlternativoEmpresaDTO>>(emailAlternativoEmpresaEntity);
        }

        public async Task CriarEmailAlternativoEmpresaAsync(EmailAlternativoEmpresaDTO emailAlternativoEmpresaDto)
        {
            var emailAlternativoEmpresaEntity = _mapper.Map<EmailAlternativoEmpresa>(emailAlternativoEmpresaDto);
            await _emailAlternativoEmpresaRepository.CriarEmailAlternativoEmpresaAsync(emailAlternativoEmpresaEntity);
        }

        public async Task DeletarEmailAlternativoEmpresaAsync(int id)
        {
            var emailAlternativoEmpresaEntity = _emailAlternativoEmpresaRepository.BuscarEmailAlternativoDeEmpresaPorIdAsync(id).Result;
            await _emailAlternativoEmpresaRepository.DeletarEmailAlternativoEmpresaAsync(emailAlternativoEmpresaEntity);
        }
    }
}
