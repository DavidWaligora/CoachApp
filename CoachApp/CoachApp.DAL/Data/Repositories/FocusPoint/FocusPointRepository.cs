using CoachApp.DAL.Data.Repositories.Generic;

namespace CoachApp.DAL.Data.Repositories.FocusPoint;

public class FocusPointRepository : GenericRepository<Models.FocusPoint>, IFocusPointRepository
{
    public FocusPointRepository(CoachAppContext context) : base(context)
    {
    }
}
