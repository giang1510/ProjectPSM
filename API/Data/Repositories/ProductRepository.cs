using API.DTOs;
using API.Entities;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

/// <summary>
/// Provide access to product data
/// </summary>
public class ProductRepository : IProductRepository
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public ProductRepository(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    // TODO implement this
    /// <summary>
    /// Get a product using name
    /// </summary>
    /// <param name="productName"></param>
    /// <returns>Complete product data</returns>
    public Task<Product?> GetProductAsync(string productName)
    {
        throw new NotImplementedException();
    }

    // TODO use Dto instead
    /// <summary>
    /// Get a product using id
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Complete product data</returns>
    public async Task<Product?> GetProductByIdAsync(int id)
    {
        return await _context.Products
            .Include(x => x.Photos)
            .Include(x => x.Reviews)
            .SingleOrDefaultAsync(x => x.Id == id);
    }

    /// <summary>
    /// Get product details using id
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Product details</returns>
    public async Task<ProductDetailDto?> GetProductDetailAsync(int id)
    {
        return await _context.Products
            .Include(x => x.Photos)
            .Include(x => x.Reviews)
            .ProjectTo<ProductDetailDto>(_mapper.ConfigurationProvider)
            .SingleOrDefaultAsync(x => x.Id == id);
    }

    // TODO parameterize this, cause all products should not be allowed
    /// <summary>
    /// Get all products
    /// </summary>
    /// <returns>List of product card data</returns>
    public async Task<IEnumerable<ProductCardDto>> GetProductsAsync()
    {
        return await _context.Products
            .Include(x => x.Photos)
            .Include(x => x.Reviews)
            .ProjectTo<ProductCardDto>(_mapper.ConfigurationProvider)
            .ToListAsync();
    }

    // TODO implement this
    /// <summary>
    /// Check if a product exists
    /// </summary>
    /// <param name="productName"></param>
    /// <returns></returns>
    public Task<bool> ProductExists(string productName)
    {
        throw new NotImplementedException();
    }

    // TODO implement this
    /// <summary>
    /// Store product related changes to database
    /// </summary>
    /// <returns>bool: if storing is successful</returns>
    public async Task<bool> SaveAllAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }

    // TODO implement this
    /// <summary>
    /// Apply changes to a product
    /// </summary>
    /// <param name="product"></param>
    public void Update(Product product)
    {
        throw new NotImplementedException();
    }
}
