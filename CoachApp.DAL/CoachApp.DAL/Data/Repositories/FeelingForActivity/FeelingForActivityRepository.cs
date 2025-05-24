namespace CoachApp.DAL.Data.Repositories.FeelingForActivity;

public class FeelingForActivityRepository : Generic.GenericRepository<Models.FeelingForActivity>, IFeelingForActivityRepository
{
    public FeelingForActivityRepository(CoachAppContext context) : base(context)
    {
    }
}
