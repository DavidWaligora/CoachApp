using CoachApp.DAL.Data.Repositories.Generic;

namespace CoachApp.DAL.Data.Repositories.ActivityType;

public class ActivityTypeRepository : GenericRepository<Models.ActivityType>, IActivityTypeRepository
{
    public ActivityTypeRepository(CoachAppContext context) : base(context)
    {
    }
}
