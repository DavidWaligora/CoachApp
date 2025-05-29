using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoachApp.DAL.Data.Models;

public class FeelingForActivity
{
    [Key]
    public int FeelingForActivityID { get; set; }
    public bool Before { get; set; }
    public bool During { get; set; }
    public bool After { get; set; }
    public int ActivityID { get; set; }
    public Activity Activity { get; set; } = null!;
    public int FeelingID { get; set; }
    public Feeling Feeling { get; set; } = null!;
    [Range(0, 5, ErrorMessage = "Must be between 0 and 5!")]
    public int Score { get; set; }
}
