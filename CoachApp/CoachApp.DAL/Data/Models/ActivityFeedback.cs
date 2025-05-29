using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoachApp.DAL.Data.Models;

public class ActivityFeedback
{
    [Key]
    public int ActivityFeedbackID { get; set; }
    public int ActivityID { get; set; }
    public Activity Activity { get; set; } = null!;
    [Column(TypeName = "VARCHAR")]
    [StringLength(255)]
    [MaxLength(255, ErrorMessage = "Cannot exceed 255 characters!")]
    public string Feedback { get; set; } = null!;
}
