List<Account> accountList = new List<Account>
{
    new Account("johndoe@example.com", "pass"),
    new Account("alicesmith@example.com", "securePwd567"),
    new Account("bobjohnson@example.com", "passw0rd!"),
    new Account("emilybrownexample.com", "mySecretPass"),
    new Account("michaelwilson@example.com", "strongPass456"),
    new Account("sarahjohnson@example.com", "safePassword789"),
    new Account("davidmiller@example.com", "superSecurePwd"),
    new Account("lindadavis@example.com", "topSecretPass"),
    new Account("jamesclark@example.com", "password1234"),
    new Account("jamesclark@example.com", "password1234")
};

var emailSender = new EmailSenderService();
var accountService = new AccountService(emailSender);

foreach (var account in accountList)
{
    try
    {
        await accountService.RegisterAsync(account);
        Console.WriteLine($"Registation for user {account.EmailAddress} Completed Successfully!");
    }
    catch (ArgumentOutOfRangeException ex) 
    {
        Console.WriteLine($"Exception: {account.EmailAddress} - {ex.Message}");
    }
    catch (InvalidOperationException ex)
    {
        Console.WriteLine($"Exception: {account.EmailAddress} - {ex.Message}");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Exception: {account.EmailAddress} - {ex.Message}");
    }
}