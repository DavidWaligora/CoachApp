using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoachApp.DAL.Data.Models;

public class User
{
    [Key]
    public int UserID { get; set; }
    [Column(TypeName = "VARCHAR")]
    [StringLength(50)]
    public string FirstName { get; set; } = null!;
    [Column(TypeName = "VARCHAR")]
    [StringLength(50)]
    public string LastName { get; set; } = null!;
    [Column(TypeName = "VARCHAR")]
    [StringLength(50)]
    public string UserName { get; set; } = null!;
    [Column(TypeName = "VARCHAR")]
    [StringLength(255)]
    public string Email { get; set; } = null!;
    [Column(TypeName = "VARCHAR")]
    [StringLength(255)]
    public string Password { get; set; } = null!;
    [Column(TypeName = "VARCHAR")]
    [StringLength(20)]
    public string? PhoneNumber { get; set; }
    public List<UserClient> UserClients { get; set; } = new List<UserClient>();
    public List<UserClient> ClientUserClients { get; set; } = new List<UserClient>();
    public List<UserClientFollowUp> UserClientFollowUps { get; set; } = new List<UserClientFollowUp>();
    public List<UserToken> UserTokens { get; set; } = new List<UserToken>();

}
