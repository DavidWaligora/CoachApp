using CoachApp.DAL.Data.Repositories.Generic;

namespace CoachApp.DAL.Data.Repositories.Feeling;

public class FeelingRepository : GenericRepository<Models.Feeling>, IFeelingRepository
{
    public FeelingRepository(CoachAppContext context) : base(context)
    {
    }
}
