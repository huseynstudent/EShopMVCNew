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
        Console.WriteLine("Product added to cart.");//--------------------Change
    }
}
