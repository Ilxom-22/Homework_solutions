var employeeService = new EmployeeService();

var newEmployee = new Employee("James", "Carter", true);

employeeService.Add(newEmployee);

var accountService = new AccountService(employeeService);
var performanceService = new PerformanceService(employeeService);

await accountService.CreateReportAsync(newEmployee.Id);

await performanceService.ReportPerformanceAsync(newEmployee.Id);