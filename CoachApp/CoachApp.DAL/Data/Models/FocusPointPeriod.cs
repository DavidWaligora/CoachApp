using System.ComponentModel.DataAnnotations;

namespace CoachApp.DAL.Data.Models;

public class FocusPointPeriod
{
    [Key]
    public int FocusPointsPeriodID { get; set; }
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
    public List<FocusPoint> FocusPoints { get; set; } = new List<FocusPoint>();
    public int UserClientID { get; set; }
    public UserClient UserClient { get; set; } = null!;
}
