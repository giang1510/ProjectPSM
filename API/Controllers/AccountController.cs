using System.Security.Cryptography;
using System.Text;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

/// <summary>
/// Controller to handle login and register
/// path: api/account
/// </summary>
public class AccountController : BaseApiController
{
    private readonly UserManager<AppUser> _userManager;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ITokenService _tokenService;
    private readonly IMapper _mapper;

    public AccountController(
        UserManager<AppUser> userManager,
        IUnitOfWork unitOfWork,
        ITokenService tokenService,
        IMapper mapper
    )
    {
        _userManager = userManager;
        _unitOfWork = unitOfWork;
        _tokenService = tokenService;
        _mapper = mapper;
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
        var userExistsState = await _unitOfWork.UserRepository.UserExists(
            registerDto.UserName,
            registerDto.EmailAddress
        );
        if (userExistsState == UserExistsState.UsernameExists)
            return BadRequest("Username is taken.");
        if (userExistsState == UserExistsState.EmailAddressExists)
            return BadRequest("Email address is taken.");

        // TODO Use UserManager (better mapping)
        var user = _mapper.Map<AppUser>(registerDto);
        user.UserName = registerDto.UserName.ToLower();

        // TODO use unitOfWork.UserRepository instead
        var result = await _userManager.CreateAsync(user, registerDto.Password);

        if (!result.Succeeded)
            return BadRequest(result.Errors);
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
        var user = await _unitOfWork.UserRepository.GetUserByUsernameAsync(loginDto.Username);

        // TODO better way to handle Unauthorized
        if (user == null)
            return Unauthorized("Invalid username!");

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
            Username = user.UserName!,
            Token = _tokenService.CreateToken(user),
            Id = user.Id
        };
    }
}
