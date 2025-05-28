using CoachApp.DAL.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace CoachApp.DAL.Data.Extensions;

public static class DbSeeder
{
    public static void SeedDatabase(CoachAppContext coachAppContext)
    {
        if (IsEmpty_ActivityTypes(coachAppContext))
            SeedActivityTypes(coachAppContext);

        if (IsEmpty_Feelings(coachAppContext))
            SeedFeelings(coachAppContext);
    }

    private static bool IsEmpty_ActivityTypes(CoachAppContext coachAppContext)
    {
        return !coachAppContext.ActivityType.Any();
    }

    private static bool IsEmpty_Feelings(CoachAppContext coachAppContext)
    {
        return !coachAppContext.Feeling.Any();
    }

    private static void SeedActivityTypes(CoachAppContext coachAppContext)
    {
        var activityTypes = new List<ActivityType>
        {
            new() { ActivityName = "Match" },
            new() { ActivityName = "Session" },
            new() { ActivityName = "Training" },
            new() { ActivityName = "Love" },
            new() { ActivityName = "Walk" },
            new() { ActivityName = "Run" },
            new() { ActivityName = "Rest" },
            new() { ActivityName = "Vacation" },
            new() { ActivityName = "Workout" },
            new() { ActivityName = "Meditation" },
            new() { ActivityName = "Yoga" },
            new() { ActivityName = "Recovery" },
            new() { ActivityName = "Strategy Meeting" },
            new() { ActivityName = "Team Building" },
            new() { ActivityName = "Stretching" },
            new() { ActivityName = "Injury Rehab" },
            new() { ActivityName = "Scouting" },
            new() { ActivityName = "Game Review" },
            new() { ActivityName = "Press Conference" },
            new() { ActivityName = "Photo Shoot" },
            new() { ActivityName = "Charity Event" },
            new() { ActivityName = "Fan Meetup" },
            new() { ActivityName = "Tactical Drill" },
            new() { ActivityName = "Skill Development" },
            new() { ActivityName = "Warm-Up" },
            new() { ActivityName = "Cool Down" },
            new() { ActivityName = "Nap" },
            new() { ActivityName = "Hydration Break" },
            new() { ActivityName = "Scrimmage" },
            new() { ActivityName = "Interview" },
            new() { ActivityName = "Team Lunch" },
            new() { ActivityName = "Tactics Review" },
            new() { ActivityName = "Film Study" },
            new() { ActivityName = "Media Training" },
            new() { ActivityName = "Sponsor Event" },
            new() { ActivityName = "Team Briefing" },
            new() { ActivityName = "Equipment Check" },
            new() { ActivityName = "Medical Check-up" },
            new() { ActivityName = "Team Travel" },
            new() { ActivityName = "Arrival Meeting" },
            new() { ActivityName = "Departure Meeting" },
            new() { ActivityName = "Game Strategy" },
            new() { ActivityName = "Opponent Analysis" },
            new() { ActivityName = "Mindfulness Session" },
            new() { ActivityName = "Leadership Workshop" },
            new() { ActivityName = "Mentorship Session" },
            new() { ActivityName = "Captain’s Meeting" },
            new() { ActivityName = "Post-Game Debrief" },
            new() { ActivityName = "Recovery Massage" },
            new() { ActivityName = "Mental Coaching" },
            new() { ActivityName = "Team Photo" },
            new() { ActivityName = "Uniform Fitting" },
            new() { ActivityName = "Skill Workshop" },
            new() { ActivityName = "Agility Training" },
            new() { ActivityName = "Strength Training" },
            new() { ActivityName = "Speed Drills" },
            new() { ActivityName = "Endurance Training" },
            new() { ActivityName = "Sponsor Shoot" },
            new() { ActivityName = "Social Media Session" },
            new() { ActivityName = "Community Outreach" },
            new() { ActivityName = "Team Bonding Exercise" },
            new() { ActivityName = "One-on-One Coaching" },
            new() { ActivityName = "Virtual Session" },
            new() { ActivityName = "Ice Bath" },
            new() { ActivityName = "Nutrition Planning" },
            new() { ActivityName = "Team Meeting" },
            new() { ActivityName = "Vision Board Session" },
            new() { ActivityName = "Sleep Hygiene Workshop" },
            new() { ActivityName = "Confidence Building" }
        };

        coachAppContext.ActivityType.AddRange(activityTypes);
        coachAppContext.SaveChanges();
    }

    private static void SeedFeelings(CoachAppContext coachAppContext)
    {
        var feelings = new List<Feeling>
        {
            new() { FeelingName = "Angry" },
            new() { FeelingName = "Sad" },
            new() { FeelingName = "Scared" },
            new() { FeelingName = "Confident" },
            new() { FeelingName = "Proud" },
            new() { FeelingName = "Affectionate" },
            new() { FeelingName = "Brave" },
            new() { FeelingName = "Insecure" },
            new() { FeelingName = "Assertive" },
            new() { FeelingName = "Disgusted" },
            new() { FeelingName = "Shy" },
            new() { FeelingName = "Worried" },
            new() { FeelingName = "Anxiety" },
            new() { FeelingName = "Happy" },
            new() { FeelingName = "Excited" },
            new() { FeelingName = "Grateful" },
            new() { FeelingName = "Calm" },
            new() { FeelingName = "Relaxed" },
            new() { FeelingName = "Lonely" },
            new() { FeelingName = "Frustrated" },
            new() { FeelingName = "Overwhelmed" },
            new() { FeelingName = "Jealous" },
            new() { FeelingName = "Guilty" },
            new() { FeelingName = "Ashamed" },
            new() { FeelingName = "Content" },
            new() { FeelingName = "Hopeful" },
            new() { FeelingName = "Tired" },
            new() { FeelingName = "Energetic" },
            new() { FeelingName = "Loved" },
            new() { FeelingName = "Peaceful" },
            new() { FeelingName = "Nervous" },
            new() { FeelingName = "Depressed" },
            new() { FeelingName = "Bored" },
            new() { FeelingName = "Enthusiastic" },
            new() { FeelingName = "Inspired" },
            new() { FeelingName = "Motivated" },
            new() { FeelingName = "Resentful" },
            new() { FeelingName = "Regretful" },
            new() { FeelingName = "Eager" },
            new() { FeelingName = "Indifferent" },
            new() { FeelingName = "Disconnected" },
            new() { FeelingName = "Secure" },
            new() { FeelingName = "Vulnerable" },
            new() { FeelingName = "Curious" },
            new() { FeelingName = "Playful" },
            new() { FeelingName = "Hopeful" },
            new() { FeelingName = "Panicked" },
            new() { FeelingName = "Embarrassed" },
            new() { FeelingName = "Reassured" },
            new() { FeelingName = "Fulfilled" },
            new() { FeelingName = "Optimistic" }
        };

        coachAppContext.Feeling.AddRange(feelings);
        coachAppContext.SaveChanges();
    }
}
