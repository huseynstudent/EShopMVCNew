using EShopp.DAL.Context;
using EShopp.DAL.Respositories.Abstacts;
using EShopp.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace EShopp.DAL.Respositories.Concretes;

public class OrderRepository : GenericRepository<Order>, IOrderRepository
{
    public OrderRepository(EShoppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Order>> GetAllWithProductAsync()
    {
        return await _context.Orders
            .Include(o => o.Product)
                .ThenInclude(p => p.Category)
            .ToListAsync();
    }
}