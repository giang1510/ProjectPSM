namespace API;

/// <summary>
/// Simple user data for client to gain member access
/// </summary>
public class UserDto
{
    public required string Username { get; set; }
    public required string Token { get; set; }
    public int Id { get; set; }
}
