using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MockJigsaw.Services.EmployeeAPI.Models.Dto;
using MockJigsaw.Services.EmployeeAPI.Services;

namespace MockJigsaw.Services.EmployeeAPI.Controllers;

[Route("api/login")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost]
    [AllowAnonymous]
    public Task<AuthResponseDto> Post([FromBody] LoginRequestDto loginDetails)
    {
        return _authService.CreateAuthSession(loginDetails);
    }
}