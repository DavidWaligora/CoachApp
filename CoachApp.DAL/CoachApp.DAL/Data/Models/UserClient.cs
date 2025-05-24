using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoachApp.DAL.Data.Models;

public class UserClient
{
    [Key]
    public int UserClientID { get; set; }

    public int UserID { get; set; }
    public int ClientID { get; set; }
    [ForeignKey("UserID")]
    public User User { get; set; } = null!;
    [ForeignKey("ClientID")]
    public User Client { get; set; } = null!;
    public List<UserClientFollowUp> UserClientFollowUps { get; set; } = new List<UserClientFollowUp>();
    public int UserRoleID { get; set; }
    public UserRole UserRole { get; set; } = null!;
    [Precision(0)]
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    [Precision(0)]
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    public List<Activity> Activities { get; set; } = new List<Activity>();
    public List<FocusPointPeriod> FocusPointPeriods { get; set; } = new List<FocusPointsPeriod>();
}
