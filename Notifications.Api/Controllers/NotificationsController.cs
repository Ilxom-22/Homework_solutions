using Microsoft.AspNetCore.Mvc;
using Notifications.Application.Common.Notifications.Services;
using Notifications.Domain.Entities;

namespace Notifications.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NotificationsController : ControllerBase
{
    [HttpPost("templates/email")]
    public async ValueTask<IActionResult> CreateEmailTemplateAsync(
        [FromBody] EmailTemplate emailTemplate,
        [FromServices] IEmailTemplateService emailTemplateService,
        CancellationToken cancellationToken
    ) =>
        Ok(await emailTemplateService.CreateAsync(emailTemplate, cancellationToken: cancellationToken));

    [HttpPost("templates/sms")]
    public async ValueTask<IActionResult> CreateSmsTemplateAsync(
        [FromBody] SmsTemplate smsTemplate,
        [FromServices] ISmsTemplateService smsTemplateService,
        CancellationToken cancellationToken
    ) =>
        Ok(await smsTemplateService.CreateAsync(smsTemplate, cancellationToken: cancellationToken));
}