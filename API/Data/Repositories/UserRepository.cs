using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class UserRepository : IUserRepository
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public UserRepository(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<AppUser?> GetUserByUsernameAsync(string username)
    {
        return await _context.Users.FirstOrDefaultAsync(x => x.Username == username.ToLower());
    }

    public async Task<IEnumerable<MemberDto>> GetMembersAsync()
    {
        return await _context.Users
            .ProjectTo<MemberDto>(_mapper.ConfigurationProvider)
            .ToListAsync();
    }

    public async Task<IEnumerable<AppUser>> GetUsersAsync()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task<bool> SaveAllAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }

    // TODO Implement Update(AppUser user)
    public void Update(AppUser user)
    {
        throw new NotImplementedException();
    }

    public async Task<UserExistsState> UserExists(string username, string emailAddress)
    {
        var usernameLC = username.ToLower();
        var emailAddressLC = emailAddress.ToLower();
        //TODO this query could be optimized - take max 2 items with less data then stop
        var existingUsers = await _context.Users.Where(user =>
            user.Username.Equals(usernameLC)
            || user.EmailAddress.Equals(emailAddressLC)
        ).ToListAsync();

        foreach (var user in existingUsers)
        {
            if (user.Username.Equals(usernameLC)) return UserExistsState.UsernameExists;
            if (user.EmailAddress.Equals(emailAddressLC)) return UserExistsState.EmailAddressExists;
        }

        return UserExistsState.No;
    }
}
