using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.Entities.Concrete
{
    public class Audit
    {
        public int Id { get; set; }
        public string UserId { get; set; } // İşlemi gerçekleştiren kullanıcı
        public string Action { get; set; } // Yapılan işlem (Ekleme, Güncelleme, Silme)
        public DateTime Timestamp { get; set; } // İşlem zamanı
        public string Details { get; set; } // İşlemle ilgili detaylar (örneğin, ürün adı ve ID'si)
    }
}
