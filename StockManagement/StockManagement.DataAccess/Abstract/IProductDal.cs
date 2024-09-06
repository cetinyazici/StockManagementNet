using StockManagement.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.DataAccess.Abstract
{
    public interface IProductDal : IGenericDal<Product>
    {
    }
}
