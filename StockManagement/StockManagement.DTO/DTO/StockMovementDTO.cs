using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.DTO.DTO
{
    public class StockMovementDTO
    {
        public int Id { get; set; }
        public string ProductName { get; set; } 
        public string WarehouseName { get; set; } 
        public int Quantity { get; set; }
        public DateTime MovementDate { get; set; }
        public string MovementType { get; set; } // "In" veya "Out" 

    }
}
