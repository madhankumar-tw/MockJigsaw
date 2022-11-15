namespace MockJigsaw.Services.EmployeeAPI.Security;

public interface IJwtTokenCreator
{
    public string CreateSessionToken(string loginDetailsUsername, string role);
}