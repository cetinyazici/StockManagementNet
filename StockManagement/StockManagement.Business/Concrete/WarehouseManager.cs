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
    public class WarehouseManager : IWarehouseService
    {
        private readonly IWarehouseDal _warehouseDal;

        public WarehouseManager(IWarehouseDal warehouseDal)
        {
            _warehouseDal = warehouseDal;
        }

        public void TCreate(Warehouse t)
        {
            _warehouseDal.Create(t);
        }

        public void TDelete(Warehouse t)
        {
            _warehouseDal.Delete(t);
        }

        public List<Warehouse> TGetAll()
        {
            return _warehouseDal.GetAll();
        }

        public Warehouse TGetById(int id)
        {
            return _warehouseDal.GetById(id);
        }

        public void TUpdate(Warehouse t)
        {
            _warehouseDal.Update(t);
        }
    }
}
