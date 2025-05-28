using CoachApp.DAL.Data.Repositories.Generic;

namespace CoachApp.DAL.Data.Repositories.UserToken;

public class UserTokenRepository : GenericRepository<Models.UserToken>, IUserTokenRepository
{
    public UserTokenRepository(CoachAppContext context): base(context)
    {

    }
}
