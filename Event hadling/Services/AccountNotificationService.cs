using Event_hadling.Models;

namespace Event_hadling.Services;

public class AccountNotificationService
{
    private readonly EmailSenderService _emailSenderService;
    private readonly UsersEventStore _usersEventStore;

    public AccountNotificationService(UsersEventStore userEvents, EmailSenderService emailSenderService)
    {
        _usersEventStore = userEvents;
        _emailSenderService = emailSenderService;

        _usersEventStore.OnUserAdded += _emailSenderService.SendEmailAsync;
    }
}