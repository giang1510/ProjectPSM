using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

/// <summary>
/// Provide access to user data
/// </summary>
public class UserRepository : IUserRepository
{
    private readonly UserManager<AppUser> _userManager;
    private readonly IMapper _mapper;

    public UserRepository(UserManager<AppUser> userManager, IMapper mapper)
    {
        _userManager = userManager;
        _mapper = mapper;
    }

    public async Task<AppUser?> GetUserByUsernameAsync(string username)
    {
        return await _userManager.Users.FirstOrDefaultAsync(x =>
            x.NormalizedUserName!.Equals(username.ToUpper())
        );
    }

    public async Task<IEnumerable<MemberDto>> GetMembersAsync()
    {
        return await _userManager
            .Users.ProjectTo<MemberDto>(_mapper.ConfigurationProvider)
            .ToListAsync();
    }

    public async Task<IEnumerable<AppUser>> GetUsersAsync()
    {
        return await _userManager.Users.ToListAsync();
    }

    // TODO Implement Update(AppUser user)
    public async Task<bool> Update(AppUser user)
    {
        var result = await _userManager.UpdateAsync(user);
        return result.Succeeded;
    }

    public async Task<UserExistsState> UserExists(string username, string emailAddress)
    {
        var usernameUC = username.ToUpper();
        var emailAddressUC = emailAddress.ToUpper();
        //TODO this query could be optimized - take max 2 items with less data then stop
        var existingUsers = await _userManager
            .Users.Where(user =>
                user.NormalizedUserName!.Equals(usernameUC)
                || user.NormalizedEmail!.Equals(emailAddressUC)
            )
            .ToListAsync();

        foreach (var user in existingUsers)
        {
            if (user.UserName!.Equals(usernameUC))
                return UserExistsState.UsernameExists;
            if (user.EmailAddress.Equals(emailAddressUC))
                return UserExistsState.EmailAddressExists;
        }

        return UserExistsState.No;
    }

    public async Task<IdentityResult> CreateUserAsync(AppUser user, string password)
    {
        return await _userManager.CreateAsync(user, password);
    }
}
