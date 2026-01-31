using EShopp.Aplication.Abstacts;
using EShopp.DAL.UnitOfWork;
using EShopp.Domain.Entities;

namespace EShopp.Aplication.Concretes;

public class OrderService : IOrderService
{
    private readonly IUnitOfWork _unitOfWork;

    public OrderService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Order>> GetAllOrdersAsync()
    {
        return await _unitOfWork.Orders.GetAllWithProductAsync();
    }

    public async Task RemoveProductFromCart(int id)
    {
        _unitOfWork.Orders.Delete(id);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task IncreaseQuantityAsync(int id)
    {
        var order = await _unitOfWork.Orders.GetByIdAsync(id);
        if (order != null)
        {
            order.Quantity++;
            _unitOfWork.Orders.Update(order);
            await _unitOfWork.SaveChangesAsync();
        }
    }

    public async Task DecreaseQuantityAsync(int id)
    {
        var order = await _unitOfWork.Orders.GetByIdAsync(id);
        if (order != null)
        {
            if (order.Quantity <= 1)
            {
                _unitOfWork.Orders.Delete(order.Id);
            }
            else
            {
                order.Quantity--;
                _unitOfWork.Orders.Update(order);
            }
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
