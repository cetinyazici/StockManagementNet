using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.DTO.DTO
{
    public class ProductUpdateDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public int Barcode { get; set; }
        public int SelectedSupplierId { get; set; }
        public int SelectedCategoryId { get; set; }
        public List<int> SelectedWarehouseIds { get; set; } = new List<int>();
    }
}
