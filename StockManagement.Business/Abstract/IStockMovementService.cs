﻿using StockManagement.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.Business.Abstract
{
    public interface IStockMovementService : IGenericService<StockMovement>
    {
        List<StockMovement> GetAllWithDetails();
    }
}
