using API.DTOs;
using API.Entities;

namespace API;

/// <summary>
/// Interface for ProductRepository
/// </summary>
public interface IProductRepository
{
    /// <summary>
    /// Apply changes to a product
    /// </summary>
    /// <param name="product"></param>
    void Update(Product product);

    /// <summary>
    /// Get all products
    /// </summary>
    /// <returns>List of product card data</returns>
    Task<IEnumerable<ProductCardDto>> GetProductsAsync();

    /// <summary>
    /// Get a product using name
    /// </summary>
    /// <param name="productName"></param>
    /// <returns>Complete product data</returns>
    Task<Product?> GetProductAsync(string productName);

    /// <summary>
    /// Get product details using id
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Product details</returns>
    Task<bool> ProductExists(string productName);

    /// <summary>
    /// Get a product using id
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Complete product data</returns>
    Task<Product?> GetProductByIdAsync(int id);

    /// <summary>
    /// Get product details using id
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Product details</returns>
    Task<ProductDetailDto?> GetProductDetailAsync(int id);
}
