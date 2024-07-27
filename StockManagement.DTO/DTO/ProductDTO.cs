using StockManagement.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.DTO.DTO
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public int Barcode { get; set; }
        public string SupplierName { get; set; }
        public string CategoryName { get; set; }
        public List<WarehouseStockDTO> WarehouseStocks { get; set; } = new List<WarehouseStockDTO>();

    }
}
