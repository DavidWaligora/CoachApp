using System.ComponentModel.DataAnnotations;

namespace CoachApp.DAL.Data.Models;

public class FocusPointsPeriod
{
    [Key]
    public int FocusPointsPeriodID { get; set; }
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
    public int UserClientID { get; set; }
    public List<FocusPoint> FocusPoints { get; set; } = new List<FocusPoint>();
    public UserClient UserClient { get; set; } = null!;
}
