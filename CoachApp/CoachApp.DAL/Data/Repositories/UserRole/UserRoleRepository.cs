using CoachApp.DAL.Data.Repositories.Generic;

namespace CoachApp.DAL.Data.Repositories.UserRole;

public class UserRoleRepository : GenericRepository<Models.UserRole>, IUserRoleRepository
{
    public UserRoleRepository(CoachAppContext context) : base(context)
    {
    }
}