using EShopp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EShopp.DAL.Context;

public class EShoppDbContext:DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=DESKTOP-5566K3T;Initial Catalog=EShopp;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True");
    }
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Order> Orders { get; set; }
}
