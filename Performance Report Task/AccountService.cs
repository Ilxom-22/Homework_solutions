
public class AccountService
{
    private readonly IEmployeeService _employeeService;
    private const string _folder = "Employees Data";

    public AccountService(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
        EnsureDirectoryExists();
    }

    public async Task CreateReportAsync(long id)
    {
        await Task.Run(() => _employeeService.GetById(id))
            .ContinueWith(employee => CreateFile(employee.Result));
    }

    private void CreateFile(Employee employee)
    {
        var mutex = new Mutex(false, "OpenFile");
        
        var path = Path.Combine(_folder, $"{employee.FirstName} {employee.LastName}.txt");

        mutex.WaitOne();
        File.WriteAllText(path, $"ID: {employee.Id}\nIsActive: {employee.IsActive}");
        mutex.ReleaseMutex();
    }

    private void EnsureDirectoryExists()
        => Directory.CreateDirectory(_folder);
}