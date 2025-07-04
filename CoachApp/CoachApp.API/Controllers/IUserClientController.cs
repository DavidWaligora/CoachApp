using Microsoft.AspNetCore.Mvc;

namespace CoachApp.API.Controllers;

public interface IUserClientController
{
    Task<ActionResult<string>> GetAllUserNamesWhereIsClient();
    Task<ActionResult<string>> GetAllUserNamesWhereIsCoach();
}
