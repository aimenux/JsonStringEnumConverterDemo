using Example01.Application;
using Microsoft.AspNetCore.Mvc;

namespace Example01.Controllers;

[ApiController]
[Route("[controller]")]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeService _employeeService;

    public EmployeeController(IEmployeeService employeeService)
    {
        _employeeService = employeeService ?? throw new ArgumentNullException(nameof(employeeService));
    }

    [HttpGet]
    public IEnumerable<Employee> GetEmployees([FromQuery] Country? country) => _employeeService.GetEmployees(country);
}