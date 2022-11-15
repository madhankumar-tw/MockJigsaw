using MockJigsaw.Services.EmployeeAPI.Models.Dto;
using MockJigsaw.Services.EmployeeAPI.Security;

namespace MockJigsaw.Services.EmployeeAPI.Services;

public class AuthService : IAuthService
{
    private readonly IJwtTokenCreator _jwtTokenCreator;

    public AuthService(IJwtTokenCreator jwtTokenCreator)
    {
        _jwtTokenCreator = jwtTokenCreator;
    }
    
    public Task<AuthResponseDto> CreateAuthSession(LoginRequestDto loginDetails)
    {
        if (loginDetails.username == Credentials.Employee.username && loginDetails.password == Credentials.Employee.password)
        {
            var token = _jwtTokenCreator.CreateSessionToken(loginDetails.username, "Employee");
            return Task.FromResult(new AuthResponseDto
            {
                AccessToken = token,
                TokenType = "Bearer"
            });
        }
        if (loginDetails.username == Credentials.Admin.username && loginDetails.password == Credentials.Admin.password)
        {
            var token = _jwtTokenCreator.CreateSessionToken(loginDetails.username, "Admin");
            return Task.FromResult(new AuthResponseDto
            {
                AccessToken = token,
                TokenType = "Bearer"
            });
        }
        throw new InvalidDataException("Enter valid credentials");
    }
}