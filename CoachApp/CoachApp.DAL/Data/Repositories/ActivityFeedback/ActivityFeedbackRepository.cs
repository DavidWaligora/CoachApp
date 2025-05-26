namespace CoachApp.DAL.Data.Repositories.ActivityFeedback;

public class ActivityFeedbackRepository : Generic.GenericRepository<Models.ActivityFeedback>, IActivityFeedbackRepository
{
    public ActivityFeedbackRepository(CoachAppContext context) : base(context)
    {
    }
}