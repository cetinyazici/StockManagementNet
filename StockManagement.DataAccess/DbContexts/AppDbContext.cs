using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using StockManagement.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.DataAccess.DbContexts
{
    public class AppDbContext : IdentityDbContext<AppUser, AppRole,int>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId);

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Supplier)
                .WithMany(s => s.Products)
                .HasForeignKey(p => p.SupplierId);

            modelBuilder.Entity<StockMovement>()
                .HasOne(sm => sm.Product)
                .WithMany(p => p.StockMovements)
                .HasForeignKey(sm => sm.ProductId);

            modelBuilder.Entity<StockMovement>()
                .HasOne(sm => sm.Warehouse)
                .WithMany(w => w.StockMovements)
                .HasForeignKey(sm => sm.WarehouseId);

            modelBuilder.Entity<AppUser>(entity => {
                entity.ToTable(name: "Users");
            });

            modelBuilder.Entity<AppRole>(entity => {
                entity.ToTable(name: "UserRoles");
            });
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<StockMovement> StockMovements { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<AppUser> Users { get; set; }
        public DbSet<AppRole> UserRoles { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
    }
}
