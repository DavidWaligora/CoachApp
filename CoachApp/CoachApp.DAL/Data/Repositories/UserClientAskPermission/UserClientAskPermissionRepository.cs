using CoachApp.DAL.Data.Repositories.Generic;

namespace CoachApp.DAL.Data.Repositories.UserClientAskPermission;

public class UserClientAskPermissionRepository : GenericRepository<Models.UserClientAskPermission>, IUserClientAskPermissionRepository
{
    public UserClientAskPermissionRepository(CoachAppContext context) : base(context)
    {
    }
}
