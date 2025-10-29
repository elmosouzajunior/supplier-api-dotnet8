using AutoMapper;
using Supplier.Application.Dto;
using Supplier.Application.Interfaces;
using Supplier.Domain.Repositories;
using SupplierEntity = Supplier.Domain.Entities.Supplier;

namespace Supplier.Application.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly ISupplierRepository _repository;
        private readonly IMapper _mapper;

        public SupplierService(ISupplierRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<SupplierDto> GetByIdAsync(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return _mapper.Map<SupplierDto>(entity);
        }

        public async Task<SupplierDto> CreateAsync(SupplierDto dto)
        {
            var entity = _mapper.Map<SupplierEntity>(dto);
            await _repository.AddAsync(entity);
            return _mapper.Map<SupplierDto>(entity);
        }

        public async Task DeleteAsync(Guid id) => await _repository.DeleteAsync(id);

        public async Task<IEnumerable<SupplierDto>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<SupplierDto>>(entities);
        }

        public async Task UpdateAsync(SupplierDto dto)
        {
            var entity = _mapper.Map<SupplierEntity>(dto);
            await _repository.UpdateAsync(entity);
        }

    }
}
