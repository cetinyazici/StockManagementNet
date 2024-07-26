using Microsoft.EntityFrameworkCore;
using StockManagement.DataAccess.Abstract;
using StockManagement.DataAccess.DbContexts;
using System.Collections.Generic;
using System.Linq;

namespace StockManagement.DataAccess.Repository
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        private readonly AppDbContext _appDbContext;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            _dbSet = _appDbContext.Set<T>();
        }

        public void Create(T entity)
        {
            _dbSet.Add(entity);
            _appDbContext.SaveChanges();
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
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
            _dbSet.Update(entity);
            _appDbContext.SaveChanges();
        }
    }
}
