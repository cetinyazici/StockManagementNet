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
    public class SupplierManager : ISupplierService
    {
        private readonly ISupplierDal _supplierDal;

        public SupplierManager(ISupplierDal supplierDal)
        {
            _supplierDal = supplierDal;
        }

        public void TCreate(Supplier t)
        {
            _supplierDal.Create(t);
        }

        public void TDelete(Supplier t)
        {
            _supplierDal.Delete(t);
        }

        public List<Supplier> TGetAll()
        {
            return _supplierDal.GetAll();
        }

        public Supplier TGetById(int id)
        {
            return _supplierDal.GetById(id);
        }

        public void TUpdate(Supplier t)
        {
            _supplierDal.Update(t);
        }
    }
}
