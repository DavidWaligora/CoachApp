using CoachApp.DAL.Data;
using Microsoft.EntityFrameworkCore;

namespace CoachApp.Services.UserClientData;

public class UserClientDataServices(CoachAppContext context)
{
    public async Task<string?> GetUserNameByUserID(int userId)
    {
        string? user = await context.UserClient
            .Where(x => x.UserID == userId)
            .Select(x => x.User.UserName)
            .FirstOrDefaultAsync();

        return user ?? string.Empty;
    }
    public async Task<string?> GetUserNameBClientID(int clientId)
    {
        string? client = await context.UserClient
            .Where(x => x.ClientID == clientId)
            .Select(x => x.User.UserName)
            .FirstOrDefaultAsync();

        return client ?? string.Empty;
    }
    public async Task<List<string?>> GetCoachesWhereIsClientAsync(int clientId)
    {
        List<string?> result = await context.UserClient
            .Where(x => x.ClientID == clientId)
            .Select(x => x.User.UserName)
            .ToListAsync();

        return result;
    }
    public async Task<List<string?>> GetClientsWhereIsCoach(int userId)
    {
        List<string?> result = await context.UserClient
            .Where(x => x.UserID == userId)
            .Select(x => x.Client.UserName)
            .ToListAsync();

        return result;
    }
}
