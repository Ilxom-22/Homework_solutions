using Employee_Task;

var service = new EmployeeService();

var hire = service.HireAsync("James", "Carter", "samsung6771157@gmail.com");

await Task.WhenAll(hire);

Console.WriteLine("Hiring proccess completed!");