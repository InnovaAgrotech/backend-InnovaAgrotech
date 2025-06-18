using InnatAPP.Domain.Interfaces;
using InnatAPP.Infra.Data.Context;

namespace InnatAPP.Infra.Data.UnitOfWork
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }
        public Task<int> SalvarAsync(CancellationToken ct = default)
            => _context.SaveChangesAsync(ct);
    }
}