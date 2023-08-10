using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;

public class RegistrationService : IRegistrationService
{
    private readonly Dictionary<string, User> _usersByUsername = new();
    private readonly Dictionary<string, User> _usersByEmails = new();
    private static RegistrationService _instance;



    private RegistrationService()
    {
    }



    public static RegistrationService GetInstance()
    {
        if (_instance == null)
            _instance = new RegistrationService();

        return _instance;
    }


    public void Register(string name, string lastName, string fatherName, string emailAddress, string username = "")
    {
        UpperCaseFirstLetter(ref name);
        UpperCaseFirstLetter(ref lastName);
        UpperCaseFirstLetter(ref fatherName);
        LowerCaseAndTrim(ref username);
        LowerCaseAndTrim(ref emailAddress);

        if (Add(name, lastName, fatherName, emailAddress, ref username)
            && SendEmail(emailAddress, name))
            _usersByUsername[username].IsActive = true;
    }



    public void Display()
    {
        if (_usersByUsername.Count == 0)
            Console.WriteLine("No Users yet!");

        foreach (var user in _usersByUsername.Values)
            Console.WriteLine(user);
    }


    private bool Add(string name, string lastName, string fatherName, string emailAddress, ref string username)
    {
        try
        {
            CheckName(name, lastName, fatherName);

            if (!CheckEmailAddress(emailAddress))
                throw new ArgumentException("Invalid Email Address!");

            if (_usersByEmails.ContainsKey(emailAddress))
                throw new ArgumentException("This email address already exists!");

            if (!Regex.IsMatch(username, "^[a-z][a-z0-9]*([.-_]?[a-z0-9]+)*[a-z0-9]$")
                || _usersByUsername.ContainsKey(username))
                username = GenerateUserName(name, lastName, fatherName);


            var user = new User(name, lastName, fatherName, emailAddress, username);
            _usersByUsername.Add(user.Username, user);
            _usersByEmails.Add(emailAddress, user);
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e.Message);
            return false;
        }


        return true;
    }



    private bool CheckName(string name, string lastName, string fatherName)
    {
        var pattern = "^(?=.{2,40}$)[A-Za-z]+('[A-Za-z]+)*$";
        var checker = new Regex(pattern);

        if (!checker.IsMatch(name))
            throw new ArgumentException("Invalid Name!");

        if (!checker.IsMatch(lastName))
            throw new ArgumentException("Invalid Last Name!");

        if (!checker.IsMatch(fatherName))
            throw new ArgumentException("Invalid Father Name!");

        return true;
    }



    private bool CheckEmailAddress(string emailAddress)
    {
        var pattern = @"^[a-zA-Z]{4,}[a-zA-Z0-9]*(\.[a-zA-Z0-9]{4,})*@[a-zA-Z0-9]{4,}\.[a-zA-Z]{2,}[a-zA-Z]*$";
        return Regex.IsMatch(emailAddress, pattern);
    }



    private string GenerateUserName(params string[] names)
    {
        var username = string.Empty;
        var rd = new Random();
        string[] predefinedAddings =
        {
            "ninja", "explorer", "unleashed", "extraordinaire", "dynamo", "innovator",
            "scribe", "wizard", "enigma", "adventures", "journeyman", "phantom"
        };
        char[] predefinedSeperators = { '-', '_', '.' };

        do
        {
            username = $"{names[rd.Next(names.Length)]}" +
                       $"{predefinedSeperators[rd.Next(predefinedSeperators.Length)]}" +
                       $"{predefinedAddings[rd.Next(predefinedAddings.Length)]}";
        } while (_usersByUsername.ContainsKey(username));

        return username;
    }



    private bool SendEmail(string receiverAddress, string name)
    {
        var senderEmail = "samsung6771157@gmail.com";
        var senderPassword = "gvmjcmhfrhfozrcs";

        try
        {
            var mail = new MailMessage(senderEmail, receiverAddress);
            mail.Subject = MessageConstants.RegistrationSubject.Replace(MessageConstants.CompanyToken, "Rize");
            mail.Body = MessageConstants.RegistrationMessage.Replace(MessageConstants.UserToken, name)
                .Replace(MessageConstants.CompanyToken, "Rize");

            var smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.Credentials = new NetworkCredential(senderEmail, senderPassword);
            smtpClient.EnableSsl = true;

            smtpClient.Send(mail);
        }
        catch (Exception e)
        {
            return false;
        }

        return true;
    }



    private void UpperCaseFirstLetter(ref string name)
    {
        if (name.Length >= 1)
            name = name.Substring(0, 1).ToUpper() + name.Substring(1).ToLower().Trim();
    }



    private void LowerCaseAndTrim(ref string str)
    {
        str = str.Trim().ToLower();
    }
}