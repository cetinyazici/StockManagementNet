using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.Business.Abstract
{
    public interface IAuditService
    {
        void CreateAuditLog(string userId, string action, string details);
    }
}
