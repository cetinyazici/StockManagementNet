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
    public class UserRoleManager : IUserRoleService
    {
        private readonly IUserRoleDal _userRoleDal;

        public UserRoleManager(IUserRoleDal userRoleDal)
        {
            _userRoleDal = userRoleDal;
        }

        public void TCreate(AppRole t)
        {
            _userRoleDal.Create(t);
        }

        public void TDelete(AppRole t)
        {
            _userRoleDal.Delete(t);
        }

        public List<AppRole> TGetAll()
        {
            return _userRoleDal.GetAll();
        }

        public AppRole TGetById(int id)
        {
            return _userRoleDal.GetById(id);
        }

        public void TUpdate(AppRole t)
        {
            _userRoleDal.Update(t);
        }
    }
}
