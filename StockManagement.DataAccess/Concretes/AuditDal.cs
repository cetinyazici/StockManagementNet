using StockManagement.DataAccess.Abstract;
using StockManagement.DataAccess.DbContexts;
using StockManagement.DataAccess.Repository;
using StockManagement.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.DataAccess.Concretes
{
    public class AuditDal : GenericRepository<Audit>, IAuditDal
    {
        public AuditDal(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
