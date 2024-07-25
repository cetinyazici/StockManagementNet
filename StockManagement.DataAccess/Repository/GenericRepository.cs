using Microsoft.EntityFrameworkCore;
using StockManagement.DataAccess.Abstract;
using StockManagement.DataAccess.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.DataAccess.Repository
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        private readonly AppDbContext _appDbContext;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(DbSet<T> dbSet, AppDbContext appDbContext)
        {
            _dbSet = dbSet;
            _appDbContext = appDbContext;
        }

        public void Create(T entity)
        {
            _appDbContext.Add<T>(entity);
            _appDbContext.SaveChanges();
        }

        public void Delete(T entity)
        {
            _appDbContext.Remove<T>(entity);
            _appDbContext.SaveChanges();
        }

        public List<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public void Update(T entity)
        {
            _appDbContext.Update<T>(entity);
            _appDbContext.SaveChanges();
        }
    }
}
