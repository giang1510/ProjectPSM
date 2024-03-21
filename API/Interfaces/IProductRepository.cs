using API.DTOs;
using API.Entities;

namespace API;

public interface IProductRepository
{
    void Update(Product product);
    Task<bool> SaveAllAsync();
    Task<IEnumerable<ProductCardDto>> GetProductsAsync();
    Task<AppUser?> GetProductAsync(string productName);
    Task<bool> ProductExists(string productName);
}
