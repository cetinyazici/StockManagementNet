using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.Entities.Concrete
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public int Barcode { get; set; }
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; } // Navigation Property
        public ICollection<StockMovement> StockMovements { get; set; } = new List<StockMovement>(); // Navigation Property
        public int CategoryId { get; set; } // Yeni Özellik
        public Category Category { get; set; } // Navigation Property

    }
}
