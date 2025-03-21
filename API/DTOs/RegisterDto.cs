﻿using System.ComponentModel.DataAnnotations;

namespace API.DTOs;

/// <summary>
/// User data to register from client to server
/// </summary>
public class RegisterDto
{
    [StringLength(64, MinimumLength = 4)]
    public required string UserName { get; set; }

    [StringLength(128, MinimumLength = 8)]
    public required string Password { get; set; }

    public required DateOnly DateOfBirth { get; set; }

    [EmailAddress]
    public required string EmailAddress { get; set; }
}
