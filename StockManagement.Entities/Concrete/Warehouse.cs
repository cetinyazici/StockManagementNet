using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.Entities.Concrete
{
    public class Warehouse
    {
        public Warehouse()
        {
            StockMovements = new List<StockMovement>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public ICollection<StockMovement> StockMovements { get; set; } // Navigation Property
    }
}
