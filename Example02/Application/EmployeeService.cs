namespace Example02.Application;

public interface IEmployeeService
{
    IEnumerable<Employee> GetEmployees(Country? country);
}

public class EmployeeService : IEmployeeService
{
    private static readonly ICollection<Employee> Employees = new List<Employee>
    {
        new Employee
        {
            FirstName = "John",
            LastName = "LeRoux",
            Country = Country.France
        },
        new Employee
        {
            FirstName = "Raul",
            LastName = "Espinoza",
            Country = Country.Spain
        },
        new Employee
        {
            FirstName = "Giovanni",
            LastName = "Don",
            Country = Country.Italy
        },
        new Employee
        {
            FirstName = "Gabriel",
            LastName = "Garcia",
            Country = Country.Portugal
        }
    };

    public IEnumerable<Employee> GetEmployees(Country? country)
    {
        return country is null ? Employees : Employees.Where(x => x.Country == country.Value);
    }
}