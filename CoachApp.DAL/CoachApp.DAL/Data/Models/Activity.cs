using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoachApp.DAL.Data.Models;

public class Activity
{
    [Key]
    public int ActivityID { get; set; }

    public int ActivityTypeID { get; set; }
    public ActivityType ActivityType { get; set; } = null!;

    public int UserClientID { get; set; }
    public UserClient UserClient { get; set; } = null!;

    [Column(TypeName = "VARCHAR")]
    [StringLength(255)]
    public string ActivityName { get; set; } = null!;
    [Column(TypeName = "VARCHAR")]
    [StringLength(255)]
    public string Description { get; set; } = null!;
    [Precision(0)]
    public DateTime StartDate { get; set; } = DateTime.Now;
    [Precision(0)]
    public DateTime EndDate { get; set; }
    public bool MustComplete { get; set; } = false;
    public bool? Completed { get; set; }
    public int FeedbackID { get; set; }
    public ActivityFeedback Feedback { get; set; } = null!;
    public List<FeelingForActivity> FeelingsForActivity { get; set; } = new List<FeelingForActivity>();
}
