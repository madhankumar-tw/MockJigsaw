using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace MockJigsaw.Services.EmployeeAPI.Security;

public class JwtTokenCreator : IJwtTokenCreator
{
    private readonly JwtSecurityTokenHandler _jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
    
    public string CreateSessionToken(string name, string role)
    {
        var issuer = "MockJigsaw";
        var key = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes("mockjigsawsecuritykeyanfropsdfjsgqpsdxamasdfnperg")),
            SecurityAlgorithms.HmacSha256);
        /*var roles = new[] { role };
        var payload = new JwtPayload
        {
            { "issuer", issuer },
            { "roles", roles }
        };*/
        var claims = new[]
        {
            new Claim("username", name),
            new Claim("role", role),
            new Claim(JwtRegisteredClaimNames.Iss, issuer),
            new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
        };
        var jwt = new JwtSecurityToken(
            claims: claims,
            signingCredentials : key
            );
        var token = _jwtSecurityTokenHandler.WriteToken(jwt);
        return token;
    }
}