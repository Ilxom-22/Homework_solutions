using System.Text.RegularExpressions;

public class AccountService
{
    private readonly List<Account> _accounts = new List<Account>();
    private readonly IEmailSenderService _emailSenderService;
    private readonly object _locker = new object();

    public AccountService(IEmailSenderService emailSenderService)
    {
        _emailSenderService = emailSenderService;
    }

    public async Task<Account> RegisterAsync(Account account)
    {
        if (!Validate(account))
            throw new ArgumentOutOfRangeException(nameof(account), "Argument did not pass validation!");

        lock (_locker)
        {
            if (Exists(account))
                throw new Exception("User with this email address already exists!");
            _accounts.Add(account);
        }
      
        if (! await _emailSenderService.SendEmailAsync(account.EmailAddress))
            throw new InvalidOperationException("Email sending Failed!");

        return account;
    }

    private bool Exists(Account newAccount)
        => _accounts.Any(account => account.EmailAddress == newAccount.EmailAddress);

    private bool Validate(Account newAccount)
    {
        var emailPattern = "^[a-zA-Z]{4,}[a-zA-Z0-9]*(\\.[a-zA-Z0-9]{4,})*@[a-zA-Z0-9]{4,}\\.[a-zA-Z]{2,}[a-zA-Z]*$";
        
        return Regex.IsMatch(newAccount.EmailAddress, emailPattern) && newAccount.Password.Length >= 8;
    }
}
