using Microsoft.EntityFrameworkCore;
using StockManagement.Business.Abstract;
using StockManagement.DataAccess.Abstract;
using StockManagement.DataAccess.DbContexts;
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
        private readonly IProductService _productService;
        private readonly AppDbContext _appDbContext;

        public StockMovementManager(IStockMovementDal stockMovementDal, AppDbContext context, IProductService productService)
        {
            _stockMovementDal = stockMovementDal;
            _appDbContext = context;
            _productService = productService;
        }

        public List<StockMovement> GetAllWithDetails()
        {
            return _appDbContext.Set<StockMovement>()
                           .Include(sm => sm.Product)
                           .Include(sm => sm.Warehouse)
                           .ToList();
        }

        public void TCreate(StockMovement stockMovement)
        {
            _stockMovementDal.Create(stockMovement);

            var product = _productService.TGetById(stockMovement.ProductId);

            if (stockMovement.MovementType == "In")
            {
                product.StockQuantity += stockMovement.Quantity;
            }
            else if (stockMovement.MovementType == "Out")
            {
                product.StockQuantity -= stockMovement.Quantity;
            }
            _productService.TUpdate(product);
        }

        public void TDelete(StockMovement stockMovement)
        {
            _stockMovementDal.Delete(stockMovement);

            var product = _productService.TGetById(stockMovement.ProductId);
            if (stockMovement.MovementType == "In")
            {
                product.StockQuantity -= stockMovement.Quantity;
            }
            else if (stockMovement.MovementType == "Out")
            {
                product.StockQuantity += stockMovement.Quantity;
            }
            _productService.TUpdate(product);
        }

        public List<StockMovement> TGetAll()
        {
            return _stockMovementDal.GetAll();
        }

        public StockMovement TGetById(int id)
        {
            return _stockMovementDal.GetById(id);
        }

        public void TUpdate(StockMovement stockMovement)
        {
            var existingStockMovement = _stockMovementDal.GetById(stockMovement.Id);
            if (existingStockMovement != null)
            {
                var product = _productService.TGetById(existingStockMovement.ProductId);
                if (existingStockMovement.MovementType == "In")
                {
                    product.StockQuantity -= existingStockMovement.Quantity;
                }
                else if (existingStockMovement.MovementType == "Out")
                {
                    product.StockQuantity += existingStockMovement.Quantity;
                }
                _productService.TUpdate(product);
            }

            _stockMovementDal.Update(stockMovement);

            var updatedProduct = _productService.TGetById(stockMovement.ProductId);
            if (stockMovement.MovementType == "In")
            {
                updatedProduct.StockQuantity += stockMovement.Quantity;
            }
            else if (stockMovement.MovementType == "Out")
            {
                updatedProduct.StockQuantity -= stockMovement.Quantity;
            }
            _productService.TUpdate(updatedProduct);
        }
    }
}
