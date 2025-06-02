using AutoMapper;
using AutoMapper.QueryableExtensions;
using CoachApp.DAL.Data;
using CoachApp.DTO.User;
using Microsoft.EntityFrameworkCore;
namespace CoachApp.Services.UserData;

public class GetUserDataServices
{
    private CoachAppContext _context;
    private readonly IMapper _mapper; // Add IMapper dependency

    public GetUserDataServices(CoachAppContext context, IMapper mapper) // Inject IMapper
    {
        _context = context;
        _mapper = mapper; // Initialize IMapper
    }

    public async Task<UserInfoDTO?> GetUserInfoByIDAsync(int id)
    {
        return await _context.User
            .Where(x => x.Id == id)
            .ProjectTo<UserInfoDTO>(_mapper.ConfigurationProvider) // Correct usage of ProjectTo
            .FirstOrDefaultAsync(); // Ensure async method is used
    }
}
