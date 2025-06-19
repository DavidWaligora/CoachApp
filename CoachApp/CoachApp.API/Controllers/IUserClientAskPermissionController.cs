using Microsoft.AspNetCore.Mvc;

namespace CoachApp.API.Controllers;

public interface IUserClientAskPermissionController
{
    Task<IActionResult> AskPermissionAsync(string userName, int? userRoleID);
    Task<ActionResult<List<string>>?> GetAllAskClientsAsync();
    Task<IActionResult> AcceptOrDeclineAskPermissionAsync(string userName, bool choice);
}
