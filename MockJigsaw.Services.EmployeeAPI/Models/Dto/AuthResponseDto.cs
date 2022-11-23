using System.Text.Json.Serialization;

namespace MockJigsaw.Services.EmployeeAPI.Models.Dto;

public class AuthResponseDto
{
    [JsonPropertyName("accessToken")]
    public string? AccessToken { get; set; }
    
    [JsonPropertyName("tokenType")]
    public string? TokenType { get; set; }
}