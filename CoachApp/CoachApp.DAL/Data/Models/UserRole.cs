using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoachApp.DAL.Data.Models;

public class UserRole
{
    [Key]
    public int UserRoleID { get; set; }
    [Column(TypeName = "VARCHAR")]
    [StringLength(50)]
    public string UserRoleName { get; set; } = null!;

    public List<UserClient> UserClients { get; set; } = new List<UserClient>(); 

}
