
using CoachApp.DAL.Data.Repositories.Activity;
using CoachApp.DAL.Data.Repositories.ActivityFeedback;
using CoachApp.DAL.Data.Repositories.ActivityType;
using CoachApp.DAL.Data.Repositories.Feeling;
using CoachApp.DAL.Data.Repositories.FeelingForActivity;
using CoachApp.DAL.Data.Repositories.FocusPoint;
using CoachApp.DAL.Data.Repositories.FocusPointPeriod;
using CoachApp.DAL.Data.Repositories.User;
using CoachApp.DAL.Data.Repositories.UserClient;
using CoachApp.DAL.Data.Repositories.UserClientAskPermission;
using CoachApp.DAL.Data.Repositories.UserClientFollowUp;
using CoachApp.DAL.Data.Repositories.UserRole;

namespace CoachApp.DAL.Data.UnitOfWork;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly CoachAppContext context;
    private IActivityRepository? _activityRepository;
    private IActivityFeedbackRepository? _activityFeedbackRepository;
    private IActivityTypeRepository? _activityTypeRepository;
    private IFeelingRepository? _feelingRepository;
    private IFeelingForActivityRepository? _feelingForActivityRepository;
    private IFocusPointRepository? _focusPointRepository;
    private IFocusPointPeriodRepository? _focusPointPeriodRepository;
    private IUserClientRepository? _userClientRepository;
    private IUserClientFollowUpRepository? _userClientFollowUpRepository;
    private IUserRoleRepository? _userRoleRepository;
    private IUserClientAskPermissionRepository? _userClientAskPermissionRepository;

    public UnitOfWork(CoachAppContext ccontext)
    {
        context = ccontext;
    }
    public IActivityRepository ActivityRepository
    {
        get { return _activityRepository ??= new ActivityRepository(context); }
    }
    public IActivityFeedbackRepository ActivityFeedbackRepository
    {
        get { return _activityFeedbackRepository ??= new ActivityFeedbackRepository(context); }
    }
    public IActivityTypeRepository ActivityTypeRepository
    {
        get { return _activityTypeRepository ??= new ActivityTypeRepository(context); }
    }
    public IFeelingRepository FeelingRepository
    {
        get { return _feelingRepository ??= new FeelingRepository(context); }
    }
    public IFeelingForActivityRepository FeelingForActivityRepository
    {
        get { return _feelingForActivityRepository ??= new FeelingForActivityRepository(context); }
    }
    public IFocusPointRepository FocusPointRepository
    {
        get { return _focusPointRepository ??= new FocusPointRepository(context); }
    }
    public IFocusPointPeriodRepository FocusPointPeriodRepository
    {
        get { return _focusPointPeriodRepository ??= new FocusPointPeriodRepository(context); }
    }
    public IUserClientRepository UserClientRepository
    {
        get { return _userClientRepository  ??= new UserClientRepository(context); }
    }
    public IUserClientFollowUpRepository UserClientFollowUpRepository
    {
        get { return _userClientFollowUpRepository ??= new UserClientFollowUpRepository(context); }
    }
    public IUserRoleRepository UserRoleRepository
    {
        get { return _userRoleRepository  ??= new UserRoleRepository(context); }
    }
    public IUserClientAskPermissionRepository UserClientAskPermissionRepository
    {
        get { return _userClientAskPermissionRepository  ??= new UserClientAskPermissionRepository(context); }
    }


    private bool disposed = false;

    protected virtual void Dispose(bool disposing)
    {
        if (!this.disposed)
        {
            if (disposing)
            {
                context.Dispose();
            }
        }
        this.disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    public async Task SaveChangesAsync()
    {
        await context.SaveChangesAsync();
    }
}
