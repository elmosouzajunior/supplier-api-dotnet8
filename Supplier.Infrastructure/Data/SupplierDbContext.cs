using Microsoft.EntityFrameworkCore;
using SupplierEntity = Supplier.Domain.Entities.Supplier;

namespace Supplier.Infrastructure.Data
{
    public class SupplierDbContext : DbContext
    {
        public SupplierDbContext(DbContextOptions<SupplierDbContext> options)
            : base(options) { }

        public DbSet<SupplierEntity> Suppliers => Set<SupplierEntity>();
    }
}
