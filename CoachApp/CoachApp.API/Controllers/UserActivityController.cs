using CoachApp.DAL.Data.Models;
using CoachApp.DAL.Data.UnitOfWork;
using CoachApp.DTO.Activity;
using CoachApp.Services.Activity;
using CoachApp.Services.UserClientData;
using CoachApp.Services.UserData;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace CoachApp.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class UserActivityController(IUnitOfWork uow, UserDataServices userDataServices, UserClientDataServices userClientDataServices, ActivityServices activityServices) : ControllerBase, IUserActivityController
    {
        [Authorize]
        [HttpPost(Name = "AddUserActivityToClient")]
        public async Task<ActionResult> AddActivityToUserClientAsync(AddActivityToUserClientDTO activity)
        {
            var identity = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrWhiteSpace(identity) || !int.TryParse(identity, out int userId))
            {
                return BadRequest();
            }

            if (activity == null || !ModelState.IsValid)
            {
                return BadRequest("Invalid activity data.");
            }

            try
            {
                var userClient = await userDataServices.GetUserInfoByIdAsync(activity.UserClientID);

                if (userClient == null) {
                    return BadRequest("User not found");
                }

                var iets = await userClientDataServices.GetClientsWhereIsCoachAsync(userId);
                if (iets == null)
                {
                    return BadRequest("Blabla");
                }

                if (!iets.Any(x => x.Contains(userClient.UserName!)))
                {
                    return Forbid("You are not authorized to add activities to this client.");
                }


                await uow.ActivityRepository.AddAsync(new DAL.Data.Models.Activity()
                {
                    ActivityTypeID = activity.ActivityTypeID,
                    UserClientID = activity.UserClientID,
                    ActivityName = activity.ActivityName,
                    Description = activity.Description,
                    StartDate = activity.StartDate,
                    EndDate = activity.EndDate,
                    MustComplete = activity.MustComplete,
                    Completed = activity.Completed,
                });
                await uow.SaveChangesAsync();
                return Ok("Activity added to user client successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize]
        [HttpGet("GetAllUserActivitiesAsClient")]
        public async Task<ActionResult<List<ActivityDTO>>> GetAllActivitiesFromUserClientWhereIsClientAsync()
        {
            var identity = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrWhiteSpace(identity) || !int.TryParse(identity, out int userId))
            {
                return BadRequest();
            }

            try
            {
                var activities = await activityServices.GetActivitiesByUserClient(userId);
                if (activities == null)
                {
                    return NotFound("No activities found for this client.");
                }
                return Ok(activities);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpGet("GetAllUserActivitiesForClientAsCoach")]
        public async Task<ActionResult<List<ActivityDTO>>> GetAllActivitiesFromUserClientWhereIsCoachAsync(int userClientID)
        {
            var identity = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrWhiteSpace(identity) || !int.TryParse(identity, out int userId))
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid data.");
            }
            try
            {
                //check if userClientID is a client of the coach (userId)
                var iets = await userClientDataServices.GetClientsIdsWhereIsCoachAsync(userId, userClientID);
                if (iets == null || !iets.Any())
                {
                    return Forbid("You are not authorized to view activities for this client.");
                }
                var activities = await activityServices.GetActivitiesByUserClient(userClientID);
                if (activities == null)
                {
                    return NotFound("No activities found for this client.");
                }
                return Ok(activities);
            }
            catch (Exception ex)
            {
                return BadRequest("Shitty message");
            }
        }
    }
}
