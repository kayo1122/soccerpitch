using System.ComponentModel.DataAnnotations;

namespace SoccerPitch.Models;

public class User
{
    // Primary key
    public int UserId { get; set; }

    // Normal username (required for normal registration,
    // optional for Google/Facebook registration)
    [MaxLength(20, ErrorMessage = "Username must be less than 20 characters")]
    public string? Username { get; set; }

    // User email
    [Required]
    [EmailAddress]
    [MaxLength(100, ErrorMessage = "Email must be less than 100 characters")]
    public string Email { get; set; } = string.Empty;

    // Password is only required for normal registration.
    // Facebook/Google users won't have a password.
    [DataType(DataType.Password)]
    [MaxLength(100, ErrorMessage = "Password must be less than 100 characters")]
    public string? Password { get; set; }

    // External login information
    // Example: "Facebook", "Google"
    public string? Provider { get; set; }

    // The unique ID returned by Facebook/Google
    public string? ProviderId { get; set; }
}