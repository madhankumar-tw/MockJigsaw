using Microsoft.EntityFrameworkCore;
using MockJigsaw.Services.EmployeeAPI.Models;

namespace MockJigsaw.Services.EmployeeAPI.DbContexts;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }
    public DbSet<Employee>? Employees { get; set; }
}