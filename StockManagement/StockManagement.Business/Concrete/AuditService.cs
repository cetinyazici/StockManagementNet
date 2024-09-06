using StockManagement.Business.Abstract;
using StockManagement.DataAccess.Abstract;
using StockManagement.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.Business.Concrete
{
    public class AuditService : IAuditService
    {
        private readonly IAuditDal _auditDal;

        public AuditService(IAuditDal auditDal)
        {
            _auditDal = auditDal;
        }

        public void CreateAuditLog(string userId, string action, string details)
        {
            var audit = new Audit
            {
                UserId = userId,
                Action = action,
                Timestamp = DateTime.Now,
                Details = details
            };
            _auditDal.Create(audit);
        }
    }
}
