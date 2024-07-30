using StockManagement.DTO.DTO;
using StockManagement.Entities.Concrete;
using System.ComponentModel.DataAnnotations;

namespace StockManagement.Web.Models
{
    public class ProductCreateViewModel
    {
        public ProductAddDTO Product { get; set; }
        public List<Supplier> Suppliers { get; set; } = new List<Supplier>();
        public List<Category> Categories { get; set; } = new List<Category>();
        public List<Warehouse> Warehouses { get; set; } = new List<Warehouse>();
        public List<int> WarehouseIds { get; set; } = new List<int>();

    }
}
