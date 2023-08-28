namespace Filter_Model_Task.Services;

internal class RegistrationService
{
    public RegistrationService(IUserService userService, IUserCredentialsService credentialsService)
    {
        _userService = userService;
        _userCredentialsService = credentialsService;
    }

    private readonly IUserService _userService;
    private readonly IUserCredentialsService _userCredentialsService;


    public bool Register(string firstName, string lastName, string emailAddress, string password)
    {
        var user = _userService.Add(firstName, lastName, emailAddress);
        if (user is null)
            return false;

        var credential = _userCredentialsService.Add(user.Id, password);
        return credential != null;
    }

}

