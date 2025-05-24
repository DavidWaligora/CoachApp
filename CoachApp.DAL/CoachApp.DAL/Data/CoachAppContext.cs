using CoachApp.DAL.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CoachApp.DAL.Data
{
    public class CoachAppContext : DbContext
    {
        public CoachAppContext(DbContextOptions<CoachAppContext> options) : base(options)
        { }

        public DbSet<Activity> Activity { get; set; } = default!;
        public DbSet<ActivityFeedback> ActivityFeedback { get; set; } = default!;
        public DbSet<ActivityType> ActivityType { get; set; } = default!;
        public DbSet<Feeling> Feeling { get; set; } = default!;
        public DbSet<FeelingForActivity> FeelingForActivity { get; set; } = default!;
        public DbSet<FocusPoint> FocusPoint { get; set; } = default!;
        public DbSet<FocusPointsPeriod> focusPointsPeriod { get; set; } = default!;
        public DbSet<User> User { get; set; } = default!;
        public DbSet<UserClient> UserClient { get; set; } = default!;
        public DbSet<UserRole> UserRole { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // model config

            modelBuilder.Entity<Activity>().ToTable("Activity");
            modelBuilder.Entity<ActivityFeedback>().ToTable("ActivityFeedback");
            modelBuilder.Entity<ActivityType>().ToTable("ActivityType");
            modelBuilder.Entity<Feeling>().ToTable("Feeling");
            modelBuilder.Entity<FeelingForActivity>().ToTable("FeelingForActivity");
            modelBuilder.Entity<FocusPoint>().ToTable("FocusPoint");
            modelBuilder.Entity<FocusPointsPeriod>().ToTable("FocusPointsPeriod");
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<UserClient>().ToTable("UserClient");
            modelBuilder.Entity<UserRole>().ToTable("UserRole");


            // Additional configurations can be added here, such as relationships, indexes, etc.

        }
        // DbSet properties for your entities can be added here, e.g.:
        // public DbSet<YourEntity> YourEntities { get; set; }
    }
}
