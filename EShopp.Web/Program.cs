using AspnetMvcAuth.Models.Entities;
using EShopp.Aplication.Abstacts;
using EShopp.Aplication.Concretes;
using EShopp.DAL.Context;
using EShopp.DAL.UnitOfWork;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<EShoppDbContext>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<ISaleService, SaleService>(); // registered sale service

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
//using AspnetMvcAuth.Context;
//using AspnetMvcAuth.Models.Entities;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.EntityFrameworkCore;

//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.
//builder.Services.AddControllersWithViews();


//builder.Services.AddDbContext<AcademyDbContext>(options =>
//{
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
//});
//builder.Services
//    .AddIdentity<ApplicationUser, IdentityRole>(options =>
//    {
//        options.SignIn.RequireConfirmedAccount = false;
//    })
//    .AddEntityFrameworkStores<AcademyDbContext>()
//    .AddDefaultTokenProviders();
//builder.Services.ConfigureApplicationCookie(options =>
//{
//    options.LoginPath = "/Account/Login";
//    options.AccessDeniedPath = "/Account/Login";
//});


//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler("/Home/Error");
//}
//app.UseStaticFiles();

//app.UseRouting();
//app.UseAuthentication();
//app.UseAuthorization();

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");

//app.Run();
