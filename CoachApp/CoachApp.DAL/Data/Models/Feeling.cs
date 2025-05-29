using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoachApp.DAL.Data.Models;

public class Feeling
{
    [Key]
    public int FeelingID { get; set; }
    [Column(TypeName = "VARCHAR")]
    [StringLength(50)]
    [MaxLength(50, ErrorMessage = "Cannot exceed 50 characters!")]
    public string FeelingName { get; set; } = null!;
    public List<FeelingForActivity> FeelingsForActivities { get; set; } = new List<FeelingForActivity>();
}
