using System.Security.Cryptography;
using System.Text;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

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

    [HttpPost("register")] // api/account/register
    public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
    {
        // TODO better way to handle bad request
        if (await _userRepository.UserExists(registerDto.Username)) return BadRequest("Username is taken.");

        // TODO Use UserManager
        using var hmac = new HMACSHA512();
        var user = new AppUser
        {
            Username = registerDto.Username.ToLower(),
            PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
            PasswordSalt = hmac.Key
        };
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return new UserDto
        {
            Username = user.Username,
            Token = _tokenService.CreateToken(user)
        };
    }

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

        return new UserDto
        {
            Username = user.Username,
            Token = _tokenService.CreateToken(user)
        };
    }
}
