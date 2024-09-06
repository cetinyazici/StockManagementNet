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

            CreateMap<Product, ProductDTO>()
                .ForMember(dest => dest.SupplierName, opt => opt.MapFrom(src => src.Supplier.Name))
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.CategoryName))
                .ForMember(dest => dest.WarehouseStocks, opt => opt.MapFrom(src => src.StockMovements
                    .GroupBy(sm => sm.Warehouse)
                    .Select(g => new WarehouseStockDTO
                    {
                        WarehouseName = g.Key.Name,
                        TotalQuantity = g.Sum(sm => sm.Quantity)
                    }).ToList())); ;

            CreateMap<ProductAddDTO, Product>()
                .ForMember(dest => dest.SupplierId, opt => opt.MapFrom(src => src.SelectedSupplierId))
                .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.SelectedCategoryId))
                .ForMember(dest => dest.StockMovements, opt => opt.Ignore()) // StockMovements'ı ilk mapleme sırasında atla
                .AfterMap((dto, product) =>
                {
                    product.StockMovements = dto.SelectedWarehouseIds.Select(id => new StockMovement
                    {
                        WarehouseId = id,
                        Quantity = dto.StockQuantity,
                        MovementType = "In", // veya ilgili hareket türü
                        MovementDate = DateTime.Now,
                        Product = product
                    }).ToList();
                });
            CreateMap<Product, ProductUpdateDTO>()
                    .ForMember(dest => dest.SelectedSupplierId, opt => opt.MapFrom(src => src.SupplierId))
                    .ForMember(dest => dest.SelectedCategoryId, opt => opt.MapFrom(src => src.CategoryId))
                    .ForMember(dest => dest.SelectedWarehouseIds, opt => opt.MapFrom(src => src.StockMovements.Select(sm => sm.WarehouseId).ToList()));

            CreateMap<ProductUpdateDTO, Product>()
                .ForMember(dest => dest.SupplierId, opt => opt.MapFrom(src => src.SelectedSupplierId))
                .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.SelectedCategoryId))
                .ForMember(dest => dest.StockMovements, opt => opt.Ignore())
                .AfterMap((dto, product) =>
                {
                    product.StockMovements = dto.SelectedWarehouseIds.Select(id => new StockMovement
                    {
                        WarehouseId = id,
                        Quantity = dto.StockQuantity,
                        MovementType = "In",
                        MovementDate = DateTime.Now,
                        Product = product
                    }).ToList();
                });
        }
    }
}
