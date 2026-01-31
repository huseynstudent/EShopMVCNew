using System.Linq;
using EShopp.Aplication.Abstacts;
using EShopp.DAL.UnitOfWork;
using EShopp.Domain.Entities;

namespace EShopp.Aplication.Concretes;

public class ProductService : IProductService
{
    private readonly IUnitOfWork _unitOfWork;

    public ProductService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task AddProduct(Product product)
    {
        await _unitOfWork.Products.AddAsync(product);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<IEnumerable<Product>> GetAllProductAsync()
    {
        return await _unitOfWork.Products.GetAllAsync();
    }

    public Task<IEnumerable<Product>> GetAllWithCategoryAsync()
    {
        return _unitOfWork.Products.GetAllWithCategoryAsync();
    }

    public async Task<Product> GetProductByIdAsync(int id)
    {
        return await _unitOfWork.Products.GetByIdAsync(id);
    }

    public async Task RemoveProduct(int id)
    {
        _unitOfWork.Products.Delete(id);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task UpdateProduct(Product category)
    {
        _unitOfWork.Products.Update(category);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task AddToCart(int id)
    {
        // If an order (cart line) for this product already exists, increment quantity.
        // Otherwise add a new order line with Quantity = 1.
        var orders = await _unitOfWork.Orders.GetAllAsync();
        var existing = orders.FirstOrDefault(o => o.ProductId == id);
        if (existing != null)
        {
            existing.Quantity++;
            _unitOfWork.Orders.Update(existing);
        }
        else
        {
            var order = new Order
            {
                ProductId = id,
                Quantity = 1
            };
            await _unitOfWork.Orders.AddAsync(order);
        }

        await _unitOfWork.SaveChangesAsync();
    }
}
