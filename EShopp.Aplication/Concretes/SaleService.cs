using EShopp.Aplication.Abstacts;
using EShopp.DAL.UnitOfWork;
using EShopp.Domain.Entities;

namespace EShopp.Aplication.Concretes;

public class SaleService : ISaleService
{
    private readonly IUnitOfWork _unitOfWork;

    public SaleService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task BuyAsync(int id)
    {
        var order = await _unitOfWork.Orders.GetByIdAsync(id);
        var product = 5;////-----------------------------finish
        _unitOfWork.Orders.Update(order);
        await _unitOfWork.SaveChangesAsync();
    }
}
