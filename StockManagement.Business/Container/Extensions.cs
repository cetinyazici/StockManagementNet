using Microsoft.Extensions.DependencyInjection;
using StockManagement.Business.Abstract;
using StockManagement.Business.Concrete;
using StockManagement.DataAccess.Abstract;
using StockManagement.DataAccess.Concretes;
using StockManagement.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.Business.Container
{
    public static class Extensions
    {
        public static void ConfigureServiceRegistration(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductManager>();
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<IStockMovementService, StockMovementManager>();
            services.AddScoped<ISupplierService, SupplierManager>();
            services.AddScoped<IUserService, UserManager>();
            services.AddScoped<IUserRoleService, UserRoleManager>();
            services.AddScoped<IWarehouseService, WarehouseManager>();
        }
        public static void ConfigureRepositoryRegistration(this IServiceCollection services)
        {
            services.AddScoped<ICategoryDal, CategoryDal>();
            services.AddScoped<IProductDal, ProductDal>();
            services.AddScoped<IStockMovementDal, StockMovementDal>();
            services.AddScoped<ISupplierDal, SupplierDal>();
            services.AddScoped<IUserDal, UserDal>();
            services.AddScoped<IUserRoleDal, UserRoleDal>();
            services.AddScoped<IWarehouseDal, WarehouseDal>();
        }
    }
}
