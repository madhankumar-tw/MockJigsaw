using MockJigsaw.Services.EmployeeAPI.Models.Dto;
using MockJigsaw.Services.EmployeeAPI.Repository;
using MockJigsaw.Services.EmployeeAPI.Security;

namespace MockJigsaw.Services.EmployeeAPI.Services;

public class AuthService : IAuthService
{
    private readonly IJwtTokenCreator _jwtTokenCreator;
    private readonly IEmployeeRepository _employeeRepository;

    public AuthService(IJwtTokenCreator jwtTokenCreator, IEmployeeRepository employeeRepository)
    {
        _jwtTokenCreator = jwtTokenCreator;
        _employeeRepository = employeeRepository;
    }
    
    public async Task<AuthResponseDto> CreateAuthSession(LoginRequestDto loginDetails)
    {
        string? token;
        if (loginDetails.Email == Credentials.Admin.Email && loginDetails.Password == Credentials.Admin.Password)
        {
            token = _jwtTokenCreator.CreateSessionToken("Administrator", "Admin");
            return await Task.FromResult(new AuthResponseDto
            {
                AccessToken = token,
                TokenType = "Bearer"
            });
        }

        var employee = await _employeeRepository.GetEmployeeByCredentials(loginDetails.Email, loginDetails.Password);
        if (employee == null) throw new InvalidDataException("Enter valid credentials");
        token = _jwtTokenCreator.CreateSessionToken(employee.Name, "Employee");
        return await Task.FromResult(new AuthResponseDto
        {
            AccessToken = token,
            TokenType = "Bearer"
        });
    }
}