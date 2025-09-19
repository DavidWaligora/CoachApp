using CoachApp.DAL.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoachApp.DTO.Activity
{
    public class ActivityDTO
    {
        public int ActivityID { get; set; }
        public int ActivityTypeID { get; set; }
        public ActivityType ActivityType { get; set; } = null!;
        public string ActivityName { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime EndDate { get; set; }
        public bool MustComplete { get; set; } = false;
        public bool? Completed { get; set; }
        public int ActivityFeedbackID { get; set; }
        public ActivityFeedback ActivityFeedback { get; set; } = null!;
        public List<FeelingForActivity> FeelingsForActivity { get; set; } = new List<FeelingForActivity>();
    }
}
