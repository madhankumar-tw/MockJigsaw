using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MockJigsaw.Services.EmployeeAPI.Models.Dto;
using MockJigsaw.Services.EmployeeAPI.Repository;

namespace MockJigsaw.Services.EmployeeAPI.Controllers;

[Route("api/employees")]
public class EmployeeAPIController : ControllerBase
{
    private ProductResponseDto _response;
    private readonly IEmployeeRepository _employeeRepository;

    public EmployeeAPIController(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
        this._response = new ProductResponseDto();
    }

    [HttpGet]
    [Authorize(Roles = "Admin")]
    public async Task<object> Get()
    {
        try
        {
            IEnumerable<EmployeeDto> employeeDtos = await _employeeRepository.GetEmployees();
            _response.Result = employeeDtos;
        }
        catch (Exception e)
        {
            _response.IsSuccess = false;
            _response.ErrorMessages = new List<string>() { e.ToString() };
        }

        return _response;
    }
    
    [HttpGet]
    [Authorize(Roles = "Admin,Employee",AuthenticationSchemes = "Employee")]
    [Route("{employeeId}")]
    public async Task<object> Get(long employeeId)
    {
        try
        {
            EmployeeDto? employeeDto = await _employeeRepository.GetEmployeeById(employeeId);
            if (employeeDto == null)
            {
                throw new Exception("The employeeId was not found in the database");
            }
            _response.Result = employeeDto;
        }
        catch (Exception e)
        {
            _response.IsSuccess = false;
            _response.ErrorMessages = new List<string>() { e.ToString() };
        }

        return _response;
    }
    
    [HttpPost]
    [Authorize(Roles = "Admin,Employee")]
    public async Task<object> Post([FromBody] EmployeeDto employeeDto)
    {
        try
        {
            EmployeeDto res = await _employeeRepository.CreateUpdateEmployee(employeeDto);
            _response.Result = res;
        }
        catch (Exception e)
        {
            _response.IsSuccess = false;
            _response.ErrorMessages = new List<string>() { e.ToString() };
        }

        return _response;
    }
    
    [HttpPut]
    [Authorize(Roles = "Admin")]
    public async Task<object> Put([FromBody] EmployeeDto employeeDto)
    {
        try
        {
            EmployeeDto res = await _employeeRepository.CreateUpdateEmployee(employeeDto);
            _response.Result = res;
        }
        catch (Exception e)
        {
            _response.IsSuccess = false;
            _response.ErrorMessages = new List<string>() { e.ToString() };
        }

        return _response;
    }
    
    [HttpDelete]
    [Authorize(Roles = "Admin")]
    public async Task<object> Delete(long employeeId)
    {
        try
        {
            bool isSuccess = await _employeeRepository.DeleteEmployee(employeeId);
            _response.Result = isSuccess;
        }
        catch (Exception e)
        {
            _response.IsSuccess = false;
            _response.ErrorMessages = new List<string>() { e.ToString() };
        }

        return _response;
    }
}