using API.Data;
using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

/// <summary>
/// Handles requests, that involve user data
/// path: api/users
/// </summary>
// TODO use DTO instead of entity 
[Authorize]
public class UsersController : BaseApiController
{
    private readonly IUserRepository _userRepository;

    public UsersController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    /// <summary>
    /// Handle getting multiple app members
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<AppUser>>> GetMembers()
    {
        var users = await _userRepository.GetMembersAsync();

        return Ok(users);
    }

    /// <summary>
    /// Handle getting information of an user
    /// </summary>
    /// <param name="username"></param>
    /// <returns></returns>
    [HttpGet("{username}")]
    public async Task<ActionResult<AppUser>> GetUser(string username)
    {
        var user = await _userRepository.GetUserByUsernameAsync(username);
        // TODO better way to handle user not found
        if (user == null)
        {
            return BadRequest($"User with username {username} could not be found!");
        }
        return Ok(user);
    }
}
