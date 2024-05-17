using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

/// <summary>
/// Provide access to user data
/// </summary>
public class UserRepository : IUserRepository
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public UserRepository(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// Get a user using username
    /// </summary>
    /// <param name="username"></param>
    /// <returns>Complete user data</returns>
    public async Task<AppUser?> GetUserByUsernameAsync(string username)
    {
        return await _context.Users.FirstOrDefaultAsync(x => x.Username == username.ToLower());
    }

    /// <summary>
    /// Get all members / registered users
    /// </summary>
    /// <returns>List of members</returns>
    public async Task<IEnumerable<MemberDto>> GetMembersAsync()
    {
        return await _context.Users
            .ProjectTo<MemberDto>(_mapper.ConfigurationProvider)
            .ToListAsync();
    }

    /// <summary>
    /// Get all users
    /// </summary>
    /// <returns>List of complete users</returns>
    public async Task<IEnumerable<AppUser>> GetUsersAsync()
    {
        return await _context.Users.ToListAsync();
    }

    /// <summary>
    /// Apply changes to database
    /// </summary>
    /// <returns>bool: if storing is successful</returns>
    public async Task<bool> SaveAllAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }

    // TODO Implement Update(AppUser user)
    /// <summary>
    /// Apply changes to a user
    /// </summary>
    /// <param name="user"></param>
    public void Update(AppUser user)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Check if a user with specific username or mail address exists
    /// </summary>
    /// <param name="username"></param>
    /// <param name="emailAddress"></param>
    /// <returns>UserExistsState</returns>
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
