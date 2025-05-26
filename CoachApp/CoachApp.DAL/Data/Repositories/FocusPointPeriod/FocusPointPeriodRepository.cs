using CoachApp.DAL.Data.Repositories.Generic;

namespace CoachApp.DAL.Data.Repositories.FocusPointPeriod;

public class FocusPointPeriodRepository : GenericRepository<Models.FocusPointPeriod>, IFocusPointPeriodRepository
{
    public FocusPointPeriodRepository(CoachAppContext context) : base(context)
    {
    }
}
