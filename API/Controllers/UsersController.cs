using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

/// <summary>
/// Handles api calls, that involve user data
/// </summary>
// TODO use repository instead of DataContext
// TODO use DTO instead of entity 
public class UsersController : BaseApiController
{
    private readonly DataContext _context;

    public UsersController(DataContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
    {
        var users = await _context.Users.ToListAsync();

        return Ok(users);
    }

    [HttpGet("{username}")]
    public async Task<ActionResult<AppUser>> GetUser(string username)
    {
        var user = await _context.Users
            .SingleOrDefaultAsync(x => x.Username == username);
        // TODO better way to handle user not found
        if (user == null)
        {
            return BadRequest($"User with username {username} could not be found!");
        }
        return Ok(user);
    }
}
