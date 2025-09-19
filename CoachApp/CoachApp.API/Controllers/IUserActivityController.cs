using CoachApp.DTO.Activity;
using Microsoft.AspNetCore.Mvc;

namespace CoachApp.API.Controllers
{
    public interface IUserActivityController
    {
        Task<ActionResult> AddActivityToUserClientAsync(AddActivityToUserClientDTO activity);
        Task<ActionResult<List<ActivityDTO>?>> GetAllActivitiesFromUserClientWhereIsClientAsync(int userClientID);
        Task<ActionResult<List<ActivityDTO>?>> GetAllActivitiesFromUserClientWhereIsCoachAsync(int userClientID);
    }
}
