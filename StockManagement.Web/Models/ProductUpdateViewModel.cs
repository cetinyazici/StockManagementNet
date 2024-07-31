using StockManagement.DTO.DTO;
using StockManagement.Entities.Concrete;

namespace StockManagement.Web.Models
{
    public class ProductUpdateViewModel
    {
        public ProductUpdateDTO Product { get; set; }
        public List<Supplier> Suppliers { get; set; }
        public List<Category> Categories { get; set; }
        public List<Warehouse> Warehouses { get; set; }
    }
}
