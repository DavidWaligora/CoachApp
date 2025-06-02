using AutoMapper;
using AutoMapper.QueryableExtensions;
using CoachApp.DAL.Data;
using CoachApp.DTO.User;
using Microsoft.EntityFrameworkCore;
namespace CoachApp.Services.UserData;

public class UserDataServices(CoachAppContext context, IMapper mapper)
{
    public async Task<UserInfoDTO?> GetUserInfoByIdAsync(int id)
    {
        return await context.User
            .Where(x => x.Id == id)
            .ProjectTo<UserInfoDTO>(mapper.ConfigurationProvider) // Correct usage of ProjectTo
            .FirstOrDefaultAsync(); // Ensure async method is used
    }
}
