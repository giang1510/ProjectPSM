using API.Entities;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class UserRepository : IUserRepository
{
    private readonly DataContext _context;

    public UserRepository(DataContext context)
    {
        _context = context;
    }
    public async Task<AppUser?> GetUserByUsernameAsync(string username)
    {
        return await _context.Users.FirstOrDefaultAsync(x => x.Username == username);
    }

    public async Task<IEnumerable<AppUser>> GetUsersAsync()
    {
        return await _context.Users.ToListAsync();
    }

    // TODO Implement SaveAllAsync()
    public Task<bool> SaveAllAsync()
    {
        throw new NotImplementedException();
    }

    // TODO Implement Update(AppUser user)
    public void Update(AppUser user)
    {
        throw new NotImplementedException();
    }
}
