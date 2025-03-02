using API.DTOs;
using API.Entities;

namespace API.Interfaces;

/// <summary>
/// Interface for user specific data repository 'service'
/// </summary>
public interface IUserRepository
{
    Task<bool> Update(AppUser user);
    Task<IEnumerable<AppUser>> GetUsersAsync();
    Task<IEnumerable<MemberDto>> GetMembersAsync();
    Task<AppUser?> GetUserByUsernameAsync(string username);
    Task<UserExistsState> UserExists(string username, string emailAddress);
    // TODO Add methods for DTO
    // Task<IEnumerable<MemberDto>> GetMembersAsync();
    // Task<MemberDto> GetMemberAsync(string username);
}

public enum UserExistsState
{
    No,
    UsernameExists,
    EmailAddressExists
}
