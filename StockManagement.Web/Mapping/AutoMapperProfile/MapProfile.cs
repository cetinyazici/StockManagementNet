using AutoMapper;
using StockManagement.DTO.DTO;
using StockManagement.Entities.Concrete;

namespace StockManagement.Web.Mapping.AutoMapperProfile
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<StockMovement, StockMovementDTO>()
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name))
                .ForMember(dest => dest.WarehouseName, opt => opt.MapFrom(src => src.Warehouse.Name));
        }
    }
}
