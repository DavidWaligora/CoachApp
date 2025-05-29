using CoachApp.DAL.Data.Repositories.Activity;
using CoachApp.DAL.Data.Repositories.ActivityFeedback;
using CoachApp.DAL.Data.Repositories.ActivityType;
using CoachApp.DAL.Data.Repositories.Feeling;
using CoachApp.DAL.Data.Repositories.FeelingForActivity;
using CoachApp.DAL.Data.Repositories.FocusPoint;
using CoachApp.DAL.Data.Repositories.FocusPointPeriod;
using CoachApp.DAL.Data.Repositories.User;
using CoachApp.DAL.Data.Repositories.UserClient;
using CoachApp.DAL.Data.Repositories.UserClientFollowUp;
using CoachApp.DAL.Data.Repositories.UserRole;

namespace CoachApp.DAL.Data.UnitOfWork;

public interface IUnitOfWork
{
    public IActivityRepository ActivityRepository { get; }
    public IActivityFeedbackRepository ActivityFeedbackRepository { get; }
    public IActivityTypeRepository ActivityTypeRepository { get; }
    public IFeelingRepository FeelingRepository { get; }
    public IFeelingForActivityRepository FeelingForActivityRepository { get; }
    public IFocusPointRepository FocusPointRepository { get; }
    public IFocusPointPeriodRepository FocusPointPeriodRepository { get; }
    public IUserRepository UserRepository { get; }
    public IUserClientRepository UserClientRepository { get; }
    public IUserClientFollowUpRepository UserClientFollowUpRepository { get; }
    public IUserRoleRepository UserRoleRepository { get; }
    public Task SaveChangesAsync();
}
