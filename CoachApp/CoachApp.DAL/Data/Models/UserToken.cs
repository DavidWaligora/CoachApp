using System.ComponentModel.DataAnnotations;

namespace CoachApp.DAL.Data.Models;

public class UserToken
{
    [Key]
    public Guid UserTokenID { get; set; }
    public int UserID { get; set; }
    public User User { get; set; } = null!;
    public DateTime ExpirationDateTime { get; set; }
}
