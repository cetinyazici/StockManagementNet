using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StockManagement.Business.Abstract;
using StockManagement.DataAccess.Abstract;
using StockManagement.DataAccess.DbContexts;
using StockManagement.DTO.DTO;
using StockManagement.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.Business.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;

        public ProductManager(IProductDal productDal, AppDbContext appDbContext, IMapper mapper)
        {
            _productDal = productDal;
            _appDbContext = appDbContext;
            _mapper = mapper;
        }

        public List<Product> GetAllWithDetails()
        {
            var products = _appDbContext.Products
                            .Include(p => p.Category)
                            .Include(p => p.Supplier)
                            .Include(p => p.StockMovements)
                                .ThenInclude(sm => sm.Warehouse)
                            .ToList();

            return products;
        }

        public void TCreate(Product t)
        {
            _productDal.Create(t);
        }

        public void TDelete(Product t)
        {
            _productDal.Delete(t);
        }

        public List<Product> TGetAll()
        {
            return _productDal.GetAll();
        }

        public Product TGetById(int id)
        {
            return _productDal.GetById(id);
        }

        public void TUpdate(Product t)
        {
            _productDal.Update(t);
        }
    }
}
