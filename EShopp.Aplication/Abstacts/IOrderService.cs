using EShopp.Domain.Entities;

namespace EShopp.Aplication.Abstacts;

public interface IOrderService
{
    Task<IEnumerable<Order>> GetAllOrdersAsync();
    Task RemoveProductFromCart(int id);
    Task IncreaseQuantityAsync(int id);
    Task DecreaseQuantityAsync(int id);
}
