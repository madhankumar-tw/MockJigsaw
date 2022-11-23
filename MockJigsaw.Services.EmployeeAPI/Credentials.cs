using System.Text.Json;
using MockJigsaw.Services.EmployeeAPI.Models;
using MockJigsaw.Services.EmployeeAPI.Models.Dto;

namespace MockJigsaw.Services.EmployeeAPI;

public static class Credentials
{
    public static readonly LoginRequestDto Admin = new LoginRequestDto
    {
        Email = "admin@company.com",
        Password = "!123@admin"
    };
}