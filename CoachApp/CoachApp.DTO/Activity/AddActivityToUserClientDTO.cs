using CoachApp.DAL.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoachApp.DTO.Activity
{
    public class AddActivityToUserClientDTO
    {
        public int ActivityTypeID { get; set; }
        public ActivityType ActivityType { get; set; } = null!;

        public int UserClientID { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(255)]
        [MaxLength(255, ErrorMessage = "Cannot exceed 255 characters!")]
        public string ActivityName { get; set; } = null!;
        [Column(TypeName = "VARCHAR")]
        [StringLength(255)]
        [MaxLength(255, ErrorMessage = "Cannot exceed 255 characters!")]
        public string Description { get; set; } = null!;
        [Precision(0)]
        public DateTime StartDate { get; set; } = DateTime.Now;
        [Precision(0)]
        public DateTime EndDate { get; set; }
        public bool MustComplete { get; set; } = false;
        public bool? Completed { get; set; }
    }
}
