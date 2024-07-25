using Microsoft.EntityFrameworkCore;
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
    public class WarehouseDal : GenericRepository<Warehouse>, IWarehouseDal
    {
        public WarehouseDal(DbSet<Warehouse> dbSet, AppDbContext appDbContext) : base(dbSet, appDbContext)
        {
        }
    }
}
