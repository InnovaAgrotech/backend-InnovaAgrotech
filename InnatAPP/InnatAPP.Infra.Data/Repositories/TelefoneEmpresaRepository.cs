using InnatAPP.Domain.Entities;
using InnatAPP.Domain.Interfaces;
using InnatAPP.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace InnatAPP.Infra.Data.Repositories
{
    public class TelefoneEmpresaRepository : ITelefoneEmpresaRepository
    {
        private ApplicationDbContext _telefoneEmpresaContext;

        public TelefoneEmpresaRepository(ApplicationDbContext context)
        {
            _telefoneEmpresaContext = context;
        }
        public async Task<TelefoneEmpresa> AtualizarTelefoneDeEmpresaAsync(TelefoneEmpresa telefoneEmpresa)
        {
            _telefoneEmpresaContext.Update(telefoneEmpresa);
            await _telefoneEmpresaContext.SaveChangesAsync();
            return telefoneEmpresa;
        }

        public async Task<TelefoneEmpresa> BuscarTelefoneDeEmpresaPorIdAsync(int id)
        {
            return await _telefoneEmpresaContext.TelefonesEmpresa.FindAsync(id);
        }

        public async Task<IEnumerable<TelefoneEmpresa>> BuscarTelefonesDeEmpresasAsync()
        {
            return await _telefoneEmpresaContext.TelefonesEmpresa.ToListAsync();
        }

        public async Task<IEnumerable<TelefoneEmpresa>> BuscarTelefonesPorEmpresaAsync(int idEmpresa)
        {
            return await _telefoneEmpresaContext.TelefonesEmpresa
                .Include(e => e.Empresa)
                .Where(e => e.IdEmpresa == idEmpresa)
                .ToListAsync();
        }

        public async Task<TelefoneEmpresa> CriarTelefoneDeEmpresaAsync(TelefoneEmpresa telefoneEmpresa)
        {
            _telefoneEmpresaContext.Add(telefoneEmpresa);
            await _telefoneEmpresaContext.SaveChangesAsync();
            return telefoneEmpresa;
        }

        public async Task<TelefoneEmpresa> DeletarTelefoneDeEmpresaAsync(TelefoneEmpresa telefoneEmpresa)
        {
            _telefoneEmpresaContext.Remove(telefoneEmpresa);
            await _telefoneEmpresaContext.SaveChangesAsync();
            return telefoneEmpresa;
        }
    }
}