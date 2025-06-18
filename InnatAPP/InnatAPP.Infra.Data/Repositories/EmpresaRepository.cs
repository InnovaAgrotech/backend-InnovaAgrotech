using InnatAPP.Domain.Entities;
using InnatAPP.Domain.Interfaces;
using InnatAPP.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace InnatAPP.Infra.Data.Repositories
{
    public class EmpresaRepository : IEmpresaRepository
    {
        private readonly ApplicationDbContext _empresaContext;

        public EmpresaRepository(ApplicationDbContext context)
        {
            _empresaContext = context;
        }

        #region Buscas

        public async Task<Empresa?> BuscarEmpresaPorIdAsync(Guid id)
            => await _empresaContext.Empresas
                                    .Include(e => e.Produtos)
                                    .FirstOrDefaultAsync(e => e.Id == id);
        public async Task<Empresa?> BuscarEmpresaPorIdDeUsuarioAsync(Guid idUsuario)
            => await _empresaContext.Empresas
                                    .Include(e => e.Produtos)
                                    .FirstOrDefaultAsync(e => e.IdUsuario == idUsuario);
        public async Task<Empresa?> BuscarEmpresaPorEmailAsync(string email)
            => await _empresaContext.Empresas
                                    .Include(e => e.Usuario)
                                    .FirstOrDefaultAsync(e => e.Usuario.Email == email);
        public async Task<IEnumerable<Empresa>> BuscarEmpresasAsync()
            => await _empresaContext.Empresas
                                    .Include(e => e.Usuario)
                                    .AsNoTracking()
                                    .ToListAsync();
        #endregion

        #region Comandos

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

        #endregion

        #region Verificação de Id de Usuário

        public async Task<bool> ExistePorUsuarioId(Guid idUsuario)
            => await _empresaContext.Empresas.AnyAsync(e => e.IdUsuario == idUsuario);

        #endregion
    }
}