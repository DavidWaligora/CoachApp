using CoachApp.DAL.Data.Repositories.Generic;

namespace CoachApp.DAL.Data.Repositories.User;

public class UserRepository : GenericRepository<Models.User>, IUserRepository
{
    public UserRepository(CoachAppContext context) : base(context)
    {
    }
}
