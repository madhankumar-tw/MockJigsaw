using System.ComponentModel.DataAnnotations;

namespace MockJigsaw.Services.EmployeeAPI.Models;

public class Employee
{
    [Key]
    public int EmployeeId { get; set; }
    [Required]
    public string? Name { get; set; }
    public string? Role { get; set; }
    public string? Office { get; set; }
    public string? Experience { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
}