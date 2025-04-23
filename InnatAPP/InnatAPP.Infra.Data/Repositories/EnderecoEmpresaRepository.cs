using InnatAPP.Domain.Entities;
using InnatAPP.Domain.Interfaces;
using InnatAPP.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace InnatAPP.Infra.Data.Repositories
{
    public class EnderecoEmpresaRepository : IEnderecoEmpresaRepository
    {
        private ApplicationDbContext _enderecoEmpresaContext;

        public EnderecoEmpresaRepository(ApplicationDbContext context)
        {
            _enderecoEmpresaContext = context;
        }
        public async Task<EnderecoEmpresa> AtualizarEnderecoDeEmpresaAsync(EnderecoEmpresa enderecoEmpresa)
        {
            _enderecoEmpresaContext.Update(enderecoEmpresa);
            await _enderecoEmpresaContext.SaveChangesAsync();
            return enderecoEmpresa;
        }

        public async Task<EnderecoEmpresa> BuscarEnderecoDeEmpresaPorIdAsync(int id)
        {
            return await _enderecoEmpresaContext.EnderecosEmpresa.FindAsync(id);
        }

        public async Task<IEnumerable<EnderecoEmpresa>> BuscarEnderecosDeEmpresasAsync()
        {
            return await _enderecoEmpresaContext.EnderecosEmpresa.ToListAsync();
        }

        public async Task<IEnumerable<EnderecoEmpresa>> BuscarEnderecosPorEmpresaAsync(int idEmpresa)
        {
            return await _enderecoEmpresaContext.EnderecosEmpresa
                .Include(e => e.Empresa)
                .Where(e => e.IdEmpresa == idEmpresa)
                .ToListAsync();
        }

        public async Task<EnderecoEmpresa> CriarEnderecoDeEmpresaAsync(EnderecoEmpresa enderecoEmpresa)
        {
            _enderecoEmpresaContext.Add(enderecoEmpresa);
            await _enderecoEmpresaContext.SaveChangesAsync();
            return enderecoEmpresa;
        }

        public async Task<EnderecoEmpresa> DeletarEnderecoDeEmpresaAsync(EnderecoEmpresa enderecoEmpresa)
        {
            _enderecoEmpresaContext.Remove(enderecoEmpresa);
            await _enderecoEmpresaContext.SaveChangesAsync();
            return enderecoEmpresa;
        }
    }
}