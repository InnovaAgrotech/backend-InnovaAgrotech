using InnatAPP.Domain.Entities;
using InnatAPP.Domain.Interfaces;
using InnatAPP.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace InnatAPP.Infra.Data.Repositories
{
    public class EnderecoRepository : IEnderecoRepository
    {
        private readonly ApplicationDbContext _enderecoContext;

        public EnderecoRepository(ApplicationDbContext context)
        {
            _enderecoContext = context;
        }

        #region Buscas

        public async Task<Endereco?> BuscarEnderecoPorIdAsync(Guid id)
        {
            return await _enderecoContext.Enderecos.FindAsync(id);
        }

        public async Task<IEnumerable<Endereco>> BuscarEnderecosAsync()
        {
            return await _enderecoContext.Enderecos.ToListAsync();
        }

        public async Task<IEnumerable<Endereco>> BuscarEnderecosPorUsuarioAsync(Guid idUsuario)
        {
            return await _enderecoContext.Enderecos
                .Include(e => e.Usuario)
                .Where(e => e.IdUsuario == idUsuario)
                .ToListAsync();
        }

        #endregion

        #region Comandos

        public async Task<Endereco> CriarEnderecoAsync(Endereco endereco)
        {
            _enderecoContext.Add(endereco);
            await _enderecoContext.SaveChangesAsync();
            return endereco;
        }

        public async Task<Endereco> AtualizarEnderecoAsync(Endereco endereco)
        {
            _enderecoContext.Update(endereco);
            await _enderecoContext.SaveChangesAsync();
            return endereco;
        }

        public async Task<Endereco> DeletarEnderecoAsync(Endereco endereco)
        {
            _enderecoContext.Remove(endereco);
            await _enderecoContext.SaveChangesAsync();
            return endereco;
        }

        #endregion
    }
}