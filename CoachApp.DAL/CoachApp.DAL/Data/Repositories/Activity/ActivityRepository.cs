namespace CoachApp.DAL.Data.Repositories.Activity;

public class ActivityRepository : Generic.GenericRepository<Models.Activity>, IActivityRepository
{
    public ActivityRepository(CoachAppContext context) : base(context)
    {
    }
}
