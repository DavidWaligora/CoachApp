using CoachApp.DAL.Data.Repositories.Generic;

namespace CoachApp.DAL.Data.Repositories.UserClient;

public class UserClientRepository : GenericRepository<Models.UserClient>, IUserClientRepository
{
    public UserClientRepository(CoachAppContext context) : base(context)
    {
    }
}
