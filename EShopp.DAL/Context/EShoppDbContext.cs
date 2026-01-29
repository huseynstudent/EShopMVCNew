using EShopp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EShopp.DAL.Context;

public class EShoppDbContext:DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=STHQ0128-01;Initial Catalog=EShoppDatabase;User ID=admin;Password=admin;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;");
    }
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
}
//