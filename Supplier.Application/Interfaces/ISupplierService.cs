using Supplier.Application.Dto;

namespace Supplier.Application.Interfaces
{
    public interface ISupplierService
    {
        Task<IEnumerable<SupplierDto>> GetAllAsync();
        Task<SupplierDto> GetByIdAsync(Guid id);
        Task<SupplierDto> CreateAsync(SupplierDto dto);
        Task UpdateAsync(SupplierDto dto);
        Task DeleteAsync(Guid id);
    }
}
