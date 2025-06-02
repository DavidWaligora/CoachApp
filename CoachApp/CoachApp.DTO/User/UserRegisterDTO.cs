using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace CoachApp.DTO.User;
public record UserRegisterDTO
{
    [Required]
    [PersonalData]
    [MaxLength(50, ErrorMessage = "Cannot exceed 50 characters!")]
    public required string FirstName { get; set; } = null!;
    [Required]
    [PersonalData]
    [MaxLength(50, ErrorMessage = "Cannot exceed 50 characters!")]
    public required string LastName { get; set; } = null!;
    [Required]
    [MaxLength(50, ErrorMessage = "Cannot exceed 50 characters!")]
    public required string UserName { get; set; } = null!;
    [Required]
    [PersonalData]
    [EmailAddress]
    [MaxLength(255, ErrorMessage = "Cannot exceed 255 characters!")]
    public required string Email { get; set; } = null!;
    [PersonalData]
    [Phone]
    [MaxLength(20, ErrorMessage = "Cannot exceed 20 characters!")]
    public string? PhoneNumber { get; set; } = null;
    [Required]
    public required string Password1 { get; set; }
    [Required]
    public required string Password2 { get; set; }
}
