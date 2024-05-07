using System.Security.Cryptography;
using System.Text;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

/// <summary>
/// Controller to handle login and register
/// path: api/account 
/// </summary>
public class AccountController : BaseApiController
{
    private readonly DataContext _context;
    private readonly IUserRepository _userRepository;
    private readonly ITokenService _tokenService;

    public AccountController(DataContext context, IUserRepository userRepository, ITokenService tokenService)
    {
        _context = context;
        _userRepository = userRepository;
        _tokenService = tokenService;
    }

    /// <summary>
    /// Handle register request
    /// </summary>
    /// <param name="registerDto"></param>
    /// <returns></returns>
    [HttpPost("register")] // api/account/register
    public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
    {
        // TODO better way to handle bad request
        var userExistsState = await _userRepository.UserExists(registerDto.Username, registerDto.EmailAddress);
        if (userExistsState == UserExistsState.UsernameExists) return BadRequest("Username is taken.");
        if (userExistsState == UserExistsState.EmailAddressExists) return BadRequest("Email address is taken.");

        // TODO Use UserManager (better mapping)
        using var hmac = new HMACSHA512();
        var user = new AppUser
        {
            Username = registerDto.Username.ToLower(),
            PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
            PasswordSalt = hmac.Key,
            EmailAddress = registerDto.EmailAddress,
            DateOfBirth = registerDto.DateOfBirth
        };
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return CreateUserDto(user);
    }

    /// <summary>
    /// Handle login request
    /// </summary>
    /// <param name="loginDto"></param>
    /// <returns></returns>
    [HttpPost("login")] // api/account/login
    public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
    {
        var user = await _userRepository.GetUserByUsernameAsync(loginDto.Username);

        // TODO better way to handle Unauthorized
        if (user == null) return Unauthorized("Invalid username!");

        using var hmac = new HMACSHA512(user.PasswordSalt);
        var passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

        for (int i = 0; i < passwordHash.Length; i++)
        {
            // TODO better way to handle Unauthorized
            if (passwordHash[i] != user.PasswordHash[i]) return Unauthorized("Invalid password!");
        }

        return CreateUserDto(user);
    }

    /// <summary>
    /// Create response user object with minimal information
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    private UserDto CreateUserDto(AppUser user)
    {
        return new UserDto
        {
            Username = user.Username,
            Token = _tokenService.CreateToken(user),
            Id = user.Id
        };
    }
}
