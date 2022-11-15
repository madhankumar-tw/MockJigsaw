using System.Text.Json;
using MockJigsaw.Services.EmployeeAPI.Models;
using MockJigsaw.Services.EmployeeAPI.Models.Dto;

namespace MockJigsaw.Services.EmployeeAPI;

public static class Credentials
{
    public static LoginRequestDto Employee = new LoginRequestDto
    {
        username = "employee1",
        password = "!123@employee"
    };
    
    public static LoginRequestDto Admin = new LoginRequestDto
    {
        username = "admin1",
        password = "!123@admin"
    };

}