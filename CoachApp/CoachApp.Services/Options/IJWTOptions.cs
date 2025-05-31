namespace CoachApp.Services.Options;

public interface IJWTOptions
{
    string Key { get; }
    string Issuer { get; }
    string Audience { get; }
    int DurationInMinutes { get; }
}
