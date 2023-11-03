using LearningCenter.Application.Common.Identity.Services;
using LearningCenter.Domain.Entities.Common.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LearningCenter.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserSettingsController : ControllerBase
{
    private readonly IUserSettingsService _userSettingsService;

    public UserSettingsController(IUserSettingsService userSettingsService)
    {
        _userSettingsService = userSettingsService;
    }

    [HttpGet]
    public IActionResult GetAllUserSettings()
        => Ok(_userSettingsService.Get(null));

    [HttpGet("{userSettingsId}")]
    public async ValueTask<IActionResult> GetUserSettingsById(Guid userSettingsId)
        => Ok(await _userSettingsService.GetByIdAsync(userSettingsId));

    [HttpPost]
    public async ValueTask<IActionResult> CreateUserSettingsAsync(UserSettings userSettings)
        => Ok(await _userSettingsService.CreateAsync(userSettings));

    [HttpPut]
    public async ValueTask<IActionResult> UpdateUserSettingsAsync(UserSettings userSettings)
        => Ok(await _userSettingsService.UpdateAsync(userSettings));

    [HttpDelete]
    public async ValueTask<IActionResult> DeleteUserSettingsAsync(UserSettings userSettings)
        => Ok(await _userSettingsService.DeleteAsync(userSettings));

    [HttpDelete("{userSettingsId}")]
    public async ValueTask<IActionResult> DeleteUserSettingsByIdAsync(Guid userSettingsId)
        => Ok(await _userSettingsService.DeleteByIdAsync(userSettingsId));
}