using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoachApp.DAL.Data.Models;

public class ActivityType
{
    [Key]
    public int ActivityTypeID { get; set; }
    [Column(TypeName = "VARCHAR")]
    [StringLength(50)]
    public string ActivityName { get; set; } = null!;
}
