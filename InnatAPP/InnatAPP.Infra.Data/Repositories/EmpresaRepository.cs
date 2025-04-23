using InnatAPP.Domain.Entities;
using InnatAPP.Domain.Interfaces;
using InnatAPP.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace InnatAPP.Infra.Data.Repositories
{
    public class EmpresaRepository : IEmpresaRepository
    {
        private ApplicationDbContext _empresaContext;

        public EmpresaRepository(ApplicationDbContext context)
        {
            _empresaContext = context;
        }
        public async Task<Empresa> AtualizarEmpresaAsync(Empresa empresa)
        {
            _empresaContext.Update(empresa);
            await _empresaContext.SaveChangesAsync();
            return empresa;
        }

        public async Task<Empresa> BuscarEmpresaPorIdAsync(int id)
        {
            return await _empresaContext.Empresas.FindAsync(id);
        }

        public async Task<IEnumerable<Empresa>> BuscarEmpresasAsync()
        {
            return await _empresaContext.Empresas.ToListAsync();
        }

        public async Task<Empresa> CriarEmpresaAsync(Empresa empresa)
        {
            _empresaContext.Add(empresa);
            await _empresaContext.SaveChangesAsync();
            return empresa;
        }

        public async Task<Empresa> DeletarEmpresaAsync(Empresa empresa)
        {
            _empresaContext.Remove(empresa);
            await _empresaContext.SaveChangesAsync();
            return empresa;
        }
    }
}