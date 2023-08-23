using System.Net.Mail;
using System.Net;
using System.Text;

namespace Employee_Task;

public class EmployeeService
{
    private readonly List<Employee> _employees;

    public EmployeeService()
    {
        _employees = new List<Employee>();
    }

    public async Task HireAsync(string name, string lastName, string email)
    {
        // Creating employee.
        var employee = new Employee(name, lastName, email);


        // Sending Confirmation Email.
        var task1 = Task.Run(() => 
        {
            var result = SendEmail(employee.Email,
                                            MessageConstants.ConfirmationEmailSubject,
                                            MessageConstants.ConfirmationEmailBody
                                            .Replace(MessageConstants.EmployeeToken, employee.FirstName));

            Console.WriteLine("Confirmation email Sent!");
            return result;
        });

        // Creating Contract File
        var task2 = Task.Run(() =>
        {
            var result = CreateFile(employee);
            Console.WriteLine("Contract file Created!");
            return result;
        });

        var result = await task1;
        var fileStream = await task2;


        // Sending Welcome Email.
        var task3 = Task.Run(() =>
        {
            var result = SendEmail(employee.Email,
                                            MessageConstants.WelcomeEmailSubject
                                                            .Replace(MessageConstants.CompanyToken, "Rize"),
                                            MessageConstants.WelcomeEmailBody
                                                            .Replace(MessageConstants.EmployeeToken, employee.FirstName));

            Console.WriteLine("Welcome Email Sent!");
            return result;
        });

        // Writing information into the Contract File.
        var data = $"{name} {lastName}'s contract.docs";
        var byteData = Encoding.UTF8.GetBytes(data);
        await fileStream.WriteAsync(byteData, 0, byteData.Length);
        fileStream.Close();

        await Task.WhenAll(task3);
        Console.WriteLine("Contract File Edited.");


        // Sending Office Plicies Email.
        var task4 = Task.Run(() =>
        {
            var result = SendEmail(employee.Email,
                                            MessageConstants.OfficePoliciesSubject,
                                            MessageConstants.OfficePoliciesBody
                                            .Replace(MessageConstants.EmployeeToken, employee.FirstName));

            Console.WriteLine("Office Policies Email Sent!");
            return result;
        });

        await Task.WhenAll(task4);

        _employees.Add(employee);
        return;
    }

    private Task<bool> SendEmail(string receiverEmailAddress, string subject, string body)
    {
        return Task.Run(async () =>
        {
            var result = true;
            try
            {
                var smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.Credentials = new NetworkCredential("sultonbek.rakhimov.recovery@gmail.com", "szabguksrhwsbtie");
                smtp.EnableSsl = true;

                var mail = new MailMessage("sultonbek.rakhimov@gmail.com", receiverEmailAddress);
                mail.Subject = subject;
                mail.Body = body;

                await smtp.SendMailAsync(mail);
            }
            catch (Exception e)
            {
                result = false;
            }

            return result;
        });
    }

    private Task<FileStream> CreateFile(Employee employee)
    {
        var newFolder = "Contract Files";
        Directory.CreateDirectory(newFolder);
        var currentDirectory = Directory.GetCurrentDirectory();

        var task = Task.Run(() => 
        {
            var path = Path.Combine(currentDirectory, newFolder, $"{employee.FirstName}_{employee.LastName}.txt");
            return File.Create(path);
        });

        return task;
    }
}
