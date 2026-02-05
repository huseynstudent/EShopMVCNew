using EShopp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EShopp.DAL.Context;


public class AcademyDbContext : IdentityDbContext<ApplicationUser>
{
    public AcademyDbContext(DbContextOptions<AcademyDbContext> options) : base(options)
    {
    }



    //Home:
    //Data Source=DESKTOP-5566K3T;Initial Catalog=EShopp;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True
    //Step
    //Data Source=STHQ0128-08;Initial Catalog=EShop;User ID=admin;Password=admin;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True

    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Order> Orders { get; set; }
}
