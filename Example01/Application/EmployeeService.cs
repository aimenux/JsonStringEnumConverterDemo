namespace Example01.Application;

public interface IEmployeeService
{
    IEnumerable<Employee> GetEmployees(Country? country);
}

public class EmployeeService : IEmployeeService
{
    private static readonly ICollection<Employee> Employees = new List<Employee>
    {
        new Employee("John", "LeRoux", Country.France),
        new Employee("Raul", "Espinoza", Country.Spain),
        new Employee("Giovanni", "Don", Country.Italy),
        new Employee("Gabriel", "Garcia", Country.Portugal)
    };

    public IEnumerable<Employee> GetEmployees(Country? country)
    {
        return country is null ? Employees : Employees.Where(x => x.Country == country.Value);
    }
}