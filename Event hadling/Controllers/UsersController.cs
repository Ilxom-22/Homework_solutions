using Event_hadling.Models;
using Event_hadling.Services;
using Microsoft.AspNetCore.Mvc;

namespace Event_hadling.Controllers;

[ApiController]
[Route("api/[controller]")]

public class UsersController : ControllerBase
{
    private readonly UserService _userService;
    private readonly AccountService _accountService;

    public UsersController(UserService userService, AccountService accountService)
    {
        _userService = userService;
        _accountService = accountService;
    }

    [HttpGet]
    public IActionResult GetUsers()
        => Ok(_userService.GetAllUsers());

    [HttpPost]
    public IActionResult AddUser(User user)
        => Ok(_accountService.CreateUser(user));
}