using CoachApp.DAL.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CoachApp.DAL.Data
{
    public class CoachAppContext : DbContext
    {
        public CoachAppContext(DbContextOptions<CoachAppContext> options) : base(options)
        { }
        // DbSet properties for your entities can be added here, e.g.:
        // public DbSet<YourEntity> YourEntities { get; set; }
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
        public DbSet<UserToken> UserToken { get; set; } = default!;
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
            modelBuilder.Entity<FocusPointPeriod>().ToTable("FocusPointsPeriod");
            modelBuilder.Entity<User>().ToTable("User")
                .HasIndex(x=>x.UserName)
                .IsUnique(); // ok
            modelBuilder.Entity<UserClient>().ToTable("UserClient");
            modelBuilder.Entity<UserRole>().ToTable("UserRole");
            modelBuilder.Entity<UserClientFollowUp>().ToTable("UserClientFollowUp");
            modelBuilder.Entity<UserToken>().ToTable("UserToken");


            // Additional configurations can be added here, such as relationships, indexes, etc.


            modelBuilder.Entity<UserClient>()
                .HasOne(uc => uc.User)
                .WithMany(u => u.UserClients)
                .HasForeignKey(uc => uc.UserID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UserClient>()
                .HasOne(uc => uc.Client)
                .WithMany(c => c.ClientUserClients)
                .HasForeignKey(uc => uc.ClientID)
                .OnDelete(DeleteBehavior.Restrict);

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

            modelBuilder.Entity<UserToken>()
                .HasOne(x=>x.User)
                .WithMany(x=>x.UserTokens)
                .HasForeignKey(x => x.UserID);


        }

    }
}
