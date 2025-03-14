using API.DTOs;
using API.Entities;
using Microsoft.AspNetCore.Identity;

namespace API.Interfaces;

/// <summary>
/// Interface for user specific data repository 'service'
/// </summary>
public interface IUserRepository
{
    Task<IdentityResult> CreateUserAsync(AppUser user, string password);

    /// <summary>
    /// Apply changes to a user
    /// </summary>
    /// <param name="user"></param>
    Task<bool> Update(AppUser user);

    /// <summary>
    /// Get all users
    /// </summary>
    /// <returns>List of complete users</returns>
    Task<IEnumerable<AppUser>> GetUsersAsync();

    /// <summary>
    /// Get all members / registered users
    /// </summary>
    /// <returns>List of members</returns>
    Task<IEnumerable<MemberDto>> GetMembersAsync();

    /// <summary>
    /// Get a user using username
    /// </summary>
    /// <param name="username"></param>
    /// <returns>Complete user data</returns>
    Task<AppUser?> GetUserByUsernameAsync(string username);

    /// <summary>
    /// Check if a user with specific username or mail address exists
    /// </summary>
    /// <param name="username"></param>
    /// <param name="emailAddress"></param>
    /// <returns>UserExistsState</returns>
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
