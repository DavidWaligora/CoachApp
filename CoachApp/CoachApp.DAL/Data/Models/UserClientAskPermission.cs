using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoachApp.DAL.Data.Models;

public class UserClientAskPermission
{
    [Key]
    public int UserClientAskPermissionID { get; set; }
    public int UserID { get; set; }
    [ForeignKey("UserID")]
    public User User { get; set; } = null!;
    public int ClientID { get; set; }
    [ForeignKey("ClientID")]
    public User Client { get; set; } = null!;
    public int? UserRoleID { get; set; }
    public UserRole? UserRole { get; set; }

    // If it is not accepted this permission cant be added again.
    // If accepted you shouldnt be able to create a new one to accept.
    // Also if accepted it generates a userclient
    public bool? HasChosen { get; set; }
}
