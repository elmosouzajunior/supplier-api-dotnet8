using Microsoft.EntityFrameworkCore;
using Supplier.Domain.Repositories;
using Supplier.Infrastructure.Data;
using SupplierEntity = Supplier.Domain.Entities.Supplier;

namespace Supplier.Infrastructure.Repositories
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly SupplierDbContext _context;

        public SupplierRepository(SupplierDbContext context)
        {
            _context = context;
        }

        public async Task<SupplierEntity> GetByIdAsync(Guid id)
            => await _context.Suppliers.FindAsync(id) ?? throw new KeyNotFoundException("Supplier not found");

        public async Task<IEnumerable<SupplierEntity>> GetAllAsync()
            => await _context.Suppliers.ToListAsync();

        public async Task AddAsync(SupplierEntity supplier)
        {
            _context.Suppliers.Add(supplier);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(SupplierEntity supplier)
        {
            _context.Suppliers.Update(supplier);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _context.Suppliers.FindAsync(id);
            if (entity != null)
            {
                _context.Suppliers.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
