using System.ComponentModel.DataAnnotations;

namespace CoachApp.DTO.User
{
    public class UpdatePasswordDTO
    {
            [Required]
            [DataType(DataType.Password)]
            public required string CurrentPassword { get; set; }

            [Required]
            [DataType(DataType.Password)]
            [MinLength(6, ErrorMessage = "Password must be at least 6 characters.")]
            public required string NewPassword { get; set; }

            [Required]
            [DataType(DataType.Password)]
            [Compare("NewPassword", ErrorMessage = "Passwords do not match.")]
            public required string ConfirmNewPassword { get; set; }
        }
    }
