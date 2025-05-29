using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoachApp.DAL.Data.Models;

public class User
{
    [Key]
    public int UserID { get; set; }
    [PersonalData]
    [Column(TypeName = "VARCHAR")]
    [StringLength(50)]
    [MaxLength(50, ErrorMessage = "Cannot exceed 50 characters!")]
    public string FirstName { get; set; } = null!;
    [PersonalData]
    [Column(TypeName = "VARCHAR")]
    [StringLength(50)]
    [MaxLength(50, ErrorMessage = "Cannot exceed 50 characters!")]
    public string LastName { get; set; } = null!;
    [Column(TypeName = "VARCHAR")]
    [StringLength(50)]
    [MaxLength(50, ErrorMessage = "Cannot exceed 50 characters!")]
    public string UserName { get; set; } = null!;
    [PersonalData]
    [Column(TypeName = "VARCHAR")]
    [EmailAddress]
    [StringLength(255)]
    [MaxLength(255, ErrorMessage = "Cannot exceed 255 characters!")]
    public string Email { get; set; } = null!;
    [Column(TypeName = "VARCHAR")]
    [StringLength(255)]
    [MaxLength(255, ErrorMessage = "Cannot exceed 255 characters!")]
    public string Password { get; set; } = null!;
    [PersonalData]
    [Column(TypeName = "VARCHAR")]
    [Phone]
    [StringLength(20)]
    [MaxLength(20, ErrorMessage = "Cannot exceed 255 characters!")]
    public string? PhoneNumber { get; set; }
    public List<UserClient> UserClients { get; set; } = new List<UserClient>();
    public List<UserClient> ClientUserClients { get; set; } = new List<UserClient>();
    public List<UserClientFollowUp> UserClientFollowUps { get; set; } = new List<UserClientFollowUp>();
    public List<UserToken> UserTokens { get; set; } = new List<UserToken>();
}
