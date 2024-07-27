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

            CreateMap<Product,ProductDTO>()
                .ForMember(dest => dest.SupplierName, opt => opt.MapFrom(src => src.Supplier.Name))
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.CategoryName))
                .ForMember(dest => dest.WarehouseStocks, opt => opt.MapFrom(src => src.StockMovements
                    .GroupBy(sm => sm.Warehouse)
                    .Select(g => new WarehouseStockDTO
                    {
                        WarehouseName = g.Key.Name,
                        TotalQuantity = g.Sum(sm => sm.Quantity)
                    }).ToList())); ;
        }
    }
}
