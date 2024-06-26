﻿using System.ComponentModel.DataAnnotations;

namespace API.Entities;

/// <summary>
/// Represents app user data row in the database
/// </summary>
public class AppUser
{
    // TODO remove unnecessary fields
    public int Id { get; set; }

    public required string Username { get; set; }
    public required byte[] PasswordHash { get; set; }
    public required byte[] PasswordSalt { get; set; }
    public required DateOnly DateOfBirth { get; set; }
    public required string EmailAddress { get; set; }
    public string? KnownAs { get; set; }
    public DateTime Created { get; set; } = DateTime.UtcNow;
    public DateTime LastActive { get; set; } = DateTime.UtcNow;
    public string? Gender { get; set; }
    public string? City { get; set; }
    public string? Country { get; set; }

    public List<Review> Reviews { get; set; } = new();

    // TODO add photos field
}
