using AutoMapper;
using AutoMapper.QueryableExtensions;
using CoachApp.DAL.Data;
using CoachApp.DTO.Activity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoachApp.Services.Activity
{
    public class ActivityServices(CoachAppContext context, IMapper mapper)
    {
        public async Task<List<ActivityDTO>?> GetActivitiesByUserClient(int userClientID)
        {
            // Implementation to retrieve activities for a specific user client
            List<ActivityDTO>? activities = await context.Activity
                .Where(x => x.UserClientID == userClientID)
                .ProjectTo<ActivityDTO>(mapper.ConfigurationProvider)
                .ToListAsync();

            return activities;
        }
    }
}
