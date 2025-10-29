namespace Supplier.Application.Dto
{
    public class SupplierDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string? DocumentNumber { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
