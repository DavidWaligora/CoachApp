using System.ComponentModel.DataAnnotations;

namespace CoachApp.DAL.Data.Models;

public class UserClientFollowUp
{
    [Key]
    public int UserClientFollowUpID { get; set; }
    public int UserClientID { get; set; }
    public UserClient UserClient { get; set; } = null!;
    public int UserID { get; set; }
    public User User { get; set; } = null!;

}
