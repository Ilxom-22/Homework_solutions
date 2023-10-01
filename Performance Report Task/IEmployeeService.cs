

public interface IEmployeeService
{
    Employee Add(Employee employee);
    Employee Update(Employee employee);
    bool Delete(Employee employee);
    Employee GetById(long id);
}