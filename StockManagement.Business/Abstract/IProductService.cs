﻿using StockManagement.DTO.DTO;
using StockManagement.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.Business.Abstract
{
    public interface IProductService : IGenericService<Product>
    {
        List<Product> GetAllWithDetails();
        Task<List<string>> GetLowStockProductNamesAsync(int threshold);
    }
}
