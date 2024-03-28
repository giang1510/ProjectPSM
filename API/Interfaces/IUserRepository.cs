using API.DTOs;
using API.Entities;

namespace API.Interfaces;

/// <summary>
/// Interface for user specific data repository 'service'
/// </summary>
public interface IUserRepository
{
    void Update(AppUser user);
    Task<bool> SaveAllAsync();
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