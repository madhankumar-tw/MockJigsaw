using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MockJigsaw.Services.EmployeeAPI.DbContexts;
using MockJigsaw.Services.EmployeeAPI.Models;
using MockJigsaw.Services.EmployeeAPI.Models.Dto;

namespace MockJigsaw.Services.EmployeeAPI.Repository;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly ApplicationDbContext _db;
    private IMapper _mapper;

    public EmployeeRepository(ApplicationDbContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<EmployeeDto>> GetEmployees()
    {
        List<Employee> employees = await _db.Employees.ToListAsync();
        return _mapper.Map<List<EmployeeDto>>(employees);
    }

    public async Task<EmployeeDto> GetEmployeeById(long employeeId)
    {
        Employee employee = await _db.Employees.Where(x=>x.EmployeeId == employeeId).FirstOrDefaultAsync();
        return _mapper.Map<EmployeeDto>(employee);
    }

    public async Task<EmployeeDto> CreateUpdateEmployee(EmployeeDto employeeDto)
    {
        Employee employee = _mapper.Map<EmployeeDto, Employee>(employeeDto);
        if (_db.Employees.Contains(employee))
        {
            _db.Employees.Update(employee);
        }
        else
        {
            _db.Add(employee);
        }

        await _db.SaveChangesAsync();
        return _mapper.Map<Employee, EmployeeDto>(employee);
    }

    public async Task<bool> DeleteEmployee(long employeeId)
    {
        Employee employee = await _db.Employees.FirstOrDefaultAsync(x => x.EmployeeId == employeeId);
        if (employee == null)
        {
            throw new Exception("The employeeId was not found the database");
        }
        _db.Employees.Remove(employee);
        await _db.SaveChangesAsync();
        return true;
    }
}