namespace CoachApp.Services.MiddleWare;

public class UserServices
{
    public bool CheckPasswordsAreTheSame(string pw1, string pw2)
    {
        return pw1 == pw2;
    }
}
