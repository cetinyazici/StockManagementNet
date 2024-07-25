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
    public class StockMovementManager : IStockMovementService
    {
        private readonly IStockMovementDal _stockMovementDal;

        public StockMovementManager(IStockMovementDal stockMovementDal)
        {
            _stockMovementDal = stockMovementDal;
        }

        public void TCreate(StockMovement t)
        {
            _stockMovementDal.Create(t);
        }

        public void TDelete(StockMovement t)
        {
            _stockMovementDal.Delete(t);
        }

        public List<StockMovement> TGetAll()
        {
            return _stockMovementDal.GetAll();
        }

        public StockMovement TGetById(int id)
        {
            return _stockMovementDal.GetById(id);
        }

        public void TUpdate(StockMovement t)
        {
            _stockMovementDal.Update(t);
        }
    }
}
