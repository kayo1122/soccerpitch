using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
namespace SoccerPitch.Models;

public class User
{
    // userId which would increment automatically
    public int UserId { get; set; }

    // username which will be asked during registration and might get used during signing in
    [Required]
    [MaxLength(20, ErrorMessage = "Username must be less than 20 characters")]
    public string Username { get; set; } = string.Empty;
    // email address which is also required for registration and optionally can be used when users log in
    [Required]
    [EmailAddress]
    [MaxLength(100, ErrorMessage = "email must be less than 100 characters")]
    public string Email { get; set; } = string.Empty;
    // This part of code might change a bit later but overall its better to has passwords in controller/separate business logic file
    [Required]
    [DataType(DataType.Password)]
    [MaxLength(100, ErrorMessage = "password must be less than 100 characters")]
    public string Password { get; set; } = string.Empty;
}
