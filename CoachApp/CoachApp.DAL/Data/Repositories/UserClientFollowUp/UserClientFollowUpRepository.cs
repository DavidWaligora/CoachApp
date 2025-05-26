using CoachApp.DAL.Data.Repositories.Generic;

namespace CoachApp.DAL.Data.Repositories.UserClientFollowUp;

public class UserClientFollowUpRepository : GenericRepository<Models.UserClientFollowUp>, IUserClientFollowUpRepository
{
    public UserClientFollowUpRepository(CoachAppContext context) : base(context)
    {
    }
}
