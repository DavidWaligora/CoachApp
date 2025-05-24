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
        public DbSet<FocusPointPeriod> focusPointsPeriod { get; set; } = default!;
        public DbSet<User> User { get; set; } = default!;
        public DbSet<UserClient> UserClient { get; set; } = default!;
        public DbSet<UserRole> UserRole { get; set; } = default!;
        public DbSet<UserClientFollowUp> UserClientFollowUp { get; set; } = default!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // model config

            modelBuilder.Entity<Activity>().ToTable("Activity"); // ok
            modelBuilder.Entity<ActivityFeedback>().ToTable("ActivityFeedback"); // ok
            modelBuilder.Entity<ActivityType>().ToTable("ActivityType"); // ok
            modelBuilder.Entity<Feeling>().ToTable("Feeling"); // ok
            modelBuilder.Entity<FeelingForActivity>().ToTable("FeelingForActivity"); // ok
            modelBuilder.Entity<FocusPoint>().ToTable("FocusPoint"); // ok
            modelBuilder.Entity<FocusPointPeriod>().ToTable("FocusPointsPeriod"); // ok
            modelBuilder.Entity<User>().ToTable("User"); // ok
            modelBuilder.Entity<UserClient>().ToTable("UserClient"); // ok
            modelBuilder.Entity<UserRole>().ToTable("UserRole");
            modelBuilder.Entity<UserClientFollowUp>().ToTable("UserClientFollowUp"); // ok


            // Additional configurations can be added here, such as relationships, indexes, etc.


            modelBuilder.Entity<UserClient>()
                .HasOne(uc => uc.User)
                .WithMany(u => u.UserClients)
                .HasForeignKey(uc => uc.UserID);

            modelBuilder.Entity<UserClient>()
                .HasOne(uc => uc.Client)
                .WithMany(c => c.UserClients)
                .HasForeignKey(uc => uc.ClientID);

            modelBuilder.Entity<Activity>()
                .HasOne(a=>a.ActivityType)
                .WithMany(at=>at.Activities)
                .HasForeignKey(at => at.ActivityTypeID);

            modelBuilder.Entity<Activity>()
                .HasOne(uc=>uc.UserClient)
                .WithMany(UserClient => UserClient.Activities)
                .HasForeignKey(uc => uc.UserClientID);

            modelBuilder.Entity<Activity>()
                .HasOne(fpp => fpp.ActivityFeedback)
                .WithOne(af => af.Activity)
                .HasForeignKey<ActivityFeedback>(af=>af.ActivityFeedbackID);

            modelBuilder.Entity<Activity>()
                .HasOne(af => af.ActivityFeedback)
                .WithOne(ActivityFeedback => ActivityFeedback.Activity)
                .HasForeignKey<ActivityFeedback>(af => af.ActivityFeedbackID);

            modelBuilder.Entity<FeelingForActivity>()
                .HasOne(x=>x.Activity)
                .WithMany(a => a.FeelingsForActivity)
                .HasForeignKey(x => x.ActivityID);

            modelBuilder.Entity<FeelingForActivity>()
                .HasOne(x => x.Feeling)
                .WithMany(f => f.FeelingsForActivities)
                .HasForeignKey(f => f.FeelingID);

            modelBuilder.Entity<FocusPoint>()
                .HasOne(fp => fp.FocusPointPeriod)
                .WithMany(uc => uc.FocusPoints)
                .HasForeignKey(fp => fp.FocusPointPeriodID);

            modelBuilder.Entity<FocusPointPeriod>()
                .HasOne(fpp => fpp.UserClient)
                .WithMany(uc => uc.FocusPointPeriods)
                .HasForeignKey(fpp => fpp.UserClientID);

            modelBuilder.Entity<UserClient>()
                .HasOne(uc => uc.UserRole)
                .WithMany(ur => ur.UserClients)
                .HasForeignKey(uc => uc.UserRoleID);

            modelBuilder.Entity<UserClientFollowUp>()
                .HasOne(ucf => ucf.UserClient)
                .WithMany(uc => uc.UserClientFollowUps)
                .HasForeignKey(ucf => ucf.UserClientID);

            modelBuilder.Entity<UserClientFollowUp>()
                .HasOne(ucf => ucf.User)
                .WithMany(u => u.UserClientFollowUps)
                .HasForeignKey(ucf => ucf.UserID);


        }
        // DbSet properties for your entities can be added here, e.g.:
        // public DbSet<YourEntity> YourEntities { get; set; }
    }
}
