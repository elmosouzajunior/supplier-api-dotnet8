using AutoMapper;
using Supplier.Application.Dto;
using SupplierEntity = Supplier.Domain.Entities.Supplier;

namespace Supplier.Application.Profiles
{
    public class SupplierProfile : Profile
    {
        public SupplierProfile()
        {
            CreateMap<SupplierEntity, SupplierDto>().ReverseMap();
        }
    }
}
