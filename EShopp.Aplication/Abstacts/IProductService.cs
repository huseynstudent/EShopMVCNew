using EShopp.Domain.Entities;

namespace EShopp.Aplication.Abstacts;

public interface IProductService
{
    Task AddProduct(Product product);
    Task RemoveProduct(int id);
    Task UpdateProduct(Product product);
    Task<IEnumerable<Product>> GetAllProductAsync();
    Task<Product> GetProductByIdAsync(int id);
    Task<IEnumerable<Product>> GetAllWithCategoryAsync();
    Task AddToCart(int id);
    Task AddStock(int id);
}
