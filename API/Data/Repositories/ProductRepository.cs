using API.DTOs;
using API.Entities;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

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
    public Task<Product?> GetProductAsync(string productName)
    {
        throw new NotImplementedException();
    }

    // TODO use Dto instead
    public async Task<Product?> GetProductByIdAsync(int id)
    {
        return await _context.Products.FindAsync(id);
    }

    public async Task<ProductDetailDto?> GetProductDetailAsync(int id)
    {
        return await _context.Products
            .Include(x => x.Photos)
            .Include(x => x.Reviews)
            .ProjectTo<ProductDetailDto>(_mapper.ConfigurationProvider)
            .SingleOrDefaultAsync(x => x.Id == id);
    }

    // TODO parameterize this, cause all products should not be allowed
    public async Task<IEnumerable<ProductCardDto>> GetProductsAsync()
    {
        return await _context.Products
            .Include(x => x.Photos)
            .Include(x => x.Reviews)
            .ProjectTo<ProductCardDto>(_mapper.ConfigurationProvider)
            .ToListAsync();
    }

    // TODO implement this
    public Task<bool> ProductExists(string productName)
    {
        throw new NotImplementedException();
    }

    // TODO implement this
    public async Task<bool> SaveAllAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }

    // TODO implement this
    public void Update(Product product)
    {
        throw new NotImplementedException();
    }
}
