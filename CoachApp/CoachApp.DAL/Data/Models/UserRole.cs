using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoachApp.DAL.Data.Models;

public class UserRole
{
    [Key]
    public int UserRoleID { get; set; }
    [Column(TypeName = "VARCHAR")]
    [StringLength(50)]
    [MaxLength(50, ErrorMessage = "Cannot exceed 50 characters!")]
    public string UserRoleName { get; set; } = null!;

    public List<UserClient> UserClients { get; set; } = [];
    public List<UserClientAskPermission> UserClientAskPermissions { get; set; } = [];

}
