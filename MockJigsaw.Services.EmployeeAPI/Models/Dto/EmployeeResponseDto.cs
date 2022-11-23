namespace MockJigsaw.Services.EmployeeAPI.Models.Dto;

public class EmployeeResponseDto
{
    public bool IsSuccess { get; set; } = true;
    public object? Result { get; set; }
    public string DisplayMessage { get; set; } = "";
    public List<string>? ErrorMessages { get; set; }
}