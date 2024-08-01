using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using StockManagement.Business.Container;
using StockManagement.DataAccess.Abstract;
using StockManagement.DataAccess.DbContexts;
using StockManagement.DataAccess.Repository;
using StockManagement.Entities.Concrete;
using StockManagement.Web.Mapping.AutoMapperProfile;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// DbContext yapýlandýrmasý
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


// Service ve Repository kayýtlarý
builder.Services.ConfigureServiceRegistration();
builder.Services.ConfigureRepositoryRegistration();


// Generic repository kaydý
builder.Services.AddScoped(typeof(IGenericDal<>), typeof(GenericRepository<>));

builder.Services.AddAutoMapper(typeof(MapProfile));

// Identity sisteminde CustomIdentityValidator kullanýlýyor.
builder.Services.AddIdentity<AppUser, AppRole>(options =>
{
    // Burada gerekirse diðer kimlik doðrulama seçenekleri de yapýlandýrýlabilir.
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
})
.AddEntityFrameworkStores<AppDbContext>()
.AddTokenProvider<DataProtectorTokenProvider<AppUser>>(TokenOptions.DefaultProvider);

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Login/SignIn/";
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseStatusCodePagesWithReExecute("/Error/Error404", "?code={0}");


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
