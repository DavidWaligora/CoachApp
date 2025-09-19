using AutoMapper;
using CoachApp.DTO.User;

namespace CoachApp.Services;

public class Mapper : Profile
{
    public Mapper()
    {
        CreateMap<DAL.Data.Models.User, UserInfoDTO>();
        CreateMap<DAL.Data.Models.Activity, DTO.Activity.ActivityDTO>();
    }
}
