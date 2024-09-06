using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.DataAccess.Abstract
{
    public interface IGenericDal<T>
    {
        void Create(T t);
        void Update(T t);
        void Delete(T t);
        List<T> GetAll();
        T GetById(int id);
    }
}
