using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoachApp.DAL.Data.Models;

public class FocusPoint
{
    [Key]
    public int FocusPointID { get; set; }
    [Column(TypeName = "VARCHAR")]
    [StringLength(50)]
    public string FocusPointName { get; set; } = null!;
    [Column(TypeName = "VARCHAR")]
    [StringLength(255)]
    public string Description { get; set; } = null!;
    public int FocusPointPeriodID { get; set; }
    public FocusPointPeriod FocusPointPeriod { get; set; } = null!;

}
