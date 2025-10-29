using SupplierEntity = Supplier.Domain.Entities.Supplier;

namespace Supplier.Domain.Repositories
{
    public interface ISupplierRepository
    {
        Task<SupplierEntity> GetByIdAsync(Guid id);
        Task<IEnumerable<SupplierEntity>> GetAllAsync();
        Task AddAsync(SupplierEntity supplier);
        Task UpdateAsync(SupplierEntity supplier);
        Task DeleteAsync(Guid id);
    }
}
