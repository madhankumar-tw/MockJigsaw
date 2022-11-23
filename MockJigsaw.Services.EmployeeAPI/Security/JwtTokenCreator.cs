using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace MockJigsaw.Services.EmployeeAPI.Security;

public class JwtTokenCreator : IJwtTokenCreator
{
    private readonly IConfiguration _config;
    private readonly JwtSecurityTokenHandler _jwtSecurityTokenHandler = new JwtSecurityTokenHandler();

    public JwtTokenCreator(IConfiguration configuration)
    {
        _config = configuration;
    }
    public string CreateSessionToken(string? name, string role)
    {
        const string issuer = "MockJigsaw";
        var key = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"])),
            SecurityAlgorithms.HmacSha256);
        var claims = new[]
        {
            new Claim("username", name!),
            new Claim("role", role),
            new Claim(JwtRegisteredClaimNames.Iss, issuer),
            new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString(CultureInfo.CurrentCulture)),
        };
        var jwt = new JwtSecurityToken(
            claims: claims,
            signingCredentials : key,
            expires: DateTime.UtcNow.AddHours(2)
            );
        var token = _jwtSecurityTokenHandler.WriteToken(jwt);
        return token;
    }
}