public class PerformanceService
{
    private readonly IEmployeeService _employeeService;
    private const string _folder = "Employees Data";

    public PerformanceService(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    public async Task ReportPerformanceAsync(long id)
    {
        await Task.Run(() => _employeeService.GetById(id))
            .ContinueWith(employee => WriteReport(employee.Result));
    }

    private void WriteReport(Employee employee)
    {
        var mutex = new Mutex(false, "OpenFile");

        var path = Path.Combine(_folder, $"{employee.FirstName} {employee.LastName}.txt");

        mutex.WaitOne();

        var data = File.ReadAllText(path);
        data += "\n\nAll Good :)";
        File.WriteAllText(path, data);

        mutex.ReleaseMutex();
    }
}