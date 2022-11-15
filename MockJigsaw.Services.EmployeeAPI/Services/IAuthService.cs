using MockJigsaw.Services.EmployeeAPI.Models.Dto;

namespace MockJigsaw.Services.EmployeeAPI.Services;

public interface IAuthService
{
    Task<AuthResponseDto> CreateAuthSession(LoginRequestDto loginRequest);
}