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
    public Task<AppUser?> GetProductAsync(string productName)
    {
        throw new NotImplementedException();
    }

    // TODO parameterize this, cause all products should not be allowed
    public async Task<IEnumerable<ProductCardDto>> GetProductsAsync()
    {
        return await _context.Products
            .Include(x => x.Photos)
            .ProjectTo<ProductCardDto>(_mapper.ConfigurationProvider)
            .ToListAsync();
    }

    // TODO implement this
    public Task<bool> ProductExists(string productName)
    {
        throw new NotImplementedException();
    }

    // TODO implement this
    public Task<bool> SaveAllAsync()
    {
        throw new NotImplementedException();
    }

    // TODO implement this
    public void Update(Product product)
    {
        throw new NotImplementedException();
    }
}
