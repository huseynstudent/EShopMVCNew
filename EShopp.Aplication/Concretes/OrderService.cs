using EShopp.Aplication.Abstacts;
using EShopp.DAL.UnitOfWork;

namespace EShopp.Aplication.Concretes;

public class OrderService : IOrderService
{
    private readonly IUnitOfWork _unitOfWork;

    public OrderService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task RemoveProductFromCart(int id)
    {
        Console.WriteLine("Product removed from cart.");//--------------------Change
    }
}
