using System.ComponentModel.DataAnnotations;

namespace CoachApp.DTO.User;
public record UserLoginDTO
{
    [Required(ErrorMessage = "Email or UserName is required!")]
    public required string UserNameOrEmail { get; set; } = null!;
    [Required(ErrorMessage = "Password is required!")]
    [DataType(DataType.Password)]
    public required string Password { get; set; } = null!;
}
