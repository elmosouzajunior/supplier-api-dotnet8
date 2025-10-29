using AutoMapper;
using Moq;
using Supplier.Application.Dto;
using Supplier.Application.Services;
using Supplier.Domain.Repositories;
using SupplierEntity = Supplier.Domain.Entities.Supplier;

namespace Supplier.Tests.Services
{
    public class SupplierServiceTests
    {
        private readonly Mock<ISupplierRepository> _repositoryMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly SupplierService _service;

        public SupplierServiceTests()
        {
            _repositoryMock = new Mock<ISupplierRepository>();
            _mapperMock = new Mock<IMapper>();
            _service = new SupplierService(_repositoryMock.Object, _mapperMock.Object);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnMappedDto()
        {
            var supplierId = Guid.NewGuid();
            var entity = new SupplierEntity { Id = supplierId, Name = "Test Supplier", DocumentNumber = "Test123", Email = "xpto@xpto.com" };
            var dto = new SupplierDto { Id = supplierId, Name = "Test Supplier", DocumentNumber = "Test123", Email = "xpto@xpto.com" };

            _repositoryMock.Setup(r => r.GetByIdAsync(supplierId))
                .ReturnsAsync(entity);

            _mapperMock.Setup(m => m.Map<SupplierDto>(entity))
                .Returns(dto);

            // Act
            var result = await _service.GetByIdAsync(supplierId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(supplierId, result.Id);
            Assert.Equal("Test Supplier", result.Name);
            Assert.Equal("Test123", result.DocumentNumber);
            Assert.Equal("xpto@xpto.com", result.Email);
            _repositoryMock.Verify(r => r.GetByIdAsync(supplierId), Times.Once);
        }

        [Fact]
        public async Task UpdateAsync_ShouldCallRepositoryUpdate()
        {
            // Arrange
            var dto = new SupplierDto { Id = Guid.NewGuid(), Name = "Updated Supplier", DocumentNumber = "Test123", Email = "xpto@xpto.com" };
            var entity = new SupplierEntity { Id = dto.Id, Name = dto.Name, DocumentNumber = dto.DocumentNumber, Email = dto.Email };

            _mapperMock.Setup(m => m.Map<SupplierEntity>(dto)).Returns(entity);

            // Act
            await _service.UpdateAsync(dto);

            // Assert
            _repositoryMock.Verify(r => r.UpdateAsync(It.Is<SupplierEntity>(s => s.Id == dto.Id)), Times.Once);
        }

        [Fact]
        public async Task DeleteAsync_ShouldCallRepositoryDelete()
        {
            // Arrange
            var id = Guid.NewGuid();

            // Act
            await _service.DeleteAsync(id);

            // Assert
            _repositoryMock.Verify(r => r.DeleteAsync(id), Times.Once);
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnMappedList()
        {
            // Arrange
            var entities = new List<SupplierEntity>
            {
                new SupplierEntity { Id = Guid.NewGuid(), Name = "A" },
                new SupplierEntity { Id = Guid.NewGuid(), Name = "B" }
            };
            var dtos = new List<SupplierDto>
            {
                new SupplierDto { Id = entities[0].Id, Name = "A" },
                new SupplierDto { Id = entities[1].Id, Name = "B" }
            };

            _repositoryMock.Setup(r => r.GetAllAsync()).ReturnsAsync(entities);
            _mapperMock.Setup(m => m.Map<IEnumerable<SupplierDto>>(entities)).Returns(dtos);

            // Act
            var result = await _service.GetAllAsync();

            // Assert
            Assert.Equal(2, result.Count());
            Assert.Contains(result, s => s.Name == "A");
            Assert.Contains(result, s => s.Name == "B");
            _repositoryMock.Verify(r => r.GetAllAsync(), Times.Once);
        }
    }
}
