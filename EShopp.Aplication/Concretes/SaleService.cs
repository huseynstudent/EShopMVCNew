using EShopp.Aplication.Abstacts;
using EShopp.DAL.UnitOfWork;

namespace EShopp.Aplication.Concretes;

public class SaleService : ISaleService
{
    private readonly IUnitOfWork _unitOfWork;

    public SaleService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> BuyAsync(int orderId)
    {
        var order = await _unitOfWork.Orders.GetByIdAsync(orderId);
        if (order is null)
        {
            return false;
        }

        var product = await _unitOfWork.Products.GetByIdAsync(order.ProductId);
        if (product != null)
        {
            product.Stock -= order.Quantity;
            _unitOfWork.Products.Update(product);
        }

        _unitOfWork.Orders.Delete(orderId);

        await _unitOfWork.SaveChangesAsync();
        return true;
    }
}
