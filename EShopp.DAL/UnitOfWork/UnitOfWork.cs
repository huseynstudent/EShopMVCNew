using EShopp.DAL.Context;
using EShopp.DAL.Respositories.Abstacts;
using EShopp.DAL.Respositories.Concretes;

namespace EShopp.DAL.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly EShoppDbContext _context;
    public ICategoryRepository Categories { get; }
    public IProductRepository Products { get; }
    public IOrderRepository Orders { get; }
    public UnitOfWork(EShoppDbContext context)
    {
        _context = context;
        Categories = new CategoryRepository(_context);
        Products = new ProductRepository(_context);
        Orders = new OrderRepository(_context);
    }
    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }

}
