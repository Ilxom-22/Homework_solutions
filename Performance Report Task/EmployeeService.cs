
using System.ComponentModel.DataAnnotations;

public class EmployeeService : IEmployeeService
{
    private readonly List<Employee> _employees = new List<Employee>();

    public Employee Add(Employee employee)
    {
        if (!ValidateEmployee(employee))
            throw new ValidationException();

        if (EmployeeExists(employee))
            throw new ArgumentException();

        var id = _employees.Count == 0 ? 1 : _employees.Last().Id + 1;
        employee.Id = id;
        _employees.Add(employee);

        return employee;
    }

    public Employee Update(Employee employee)
    {
        var foundEmployee = GetById(employee.Id);

        if (foundEmployee == null)
            throw new ArgumentOutOfRangeException();

        if (!ValidateEmployee(employee))
            throw new ValidationException();

        foundEmployee.FirstName = employee.FirstName;
        foundEmployee.LastName = employee.LastName;
        foundEmployee.IsActive = employee.IsActive;

        return foundEmployee;
    }

    public bool Delete(Employee employee)
    {
        var foundEmployee = GetById(employee.Id);

        if (foundEmployee == null)
            throw new ArgumentOutOfRangeException();

        _employees.Remove(foundEmployee);

        return true;
    }

    public Employee GetById(long id)
        => _employees.FirstOrDefault(emp => emp.Id == id) ?? throw new ArgumentException("Employee not found!");

    private bool EmployeeExists(Employee employee)
        => _employees.Any(emp => emp.Equals(employee));

    private bool ValidateEmployee(Employee employee)
    {
        if (string.IsNullOrWhiteSpace(employee.FirstName) || string.IsNullOrWhiteSpace(employee.LastName))
            return false;

        return true;
    }
}