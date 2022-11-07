using MockJigsaw.Services.EmployeeAPI.Models.Dto;

namespace MockJigsaw.Services.EmployeeAPI.Repository;

public interface IEmployeeRepository
{
    Task<IEnumerable<EmployeeDto>> GetEmployees();
    Task<EmployeeDto> GetEmployeeById(long employeeId);
    Task<EmployeeDto> CreateUpdateEmployee(EmployeeDto employeeDto);
    Task<bool> DeleteEmployee(long employeeId);
}