using File_Upload.Models.Constants;
using File_Upload.Services.Processing;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace File_Upload.Controller;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class FilesController : ControllerBase
{
    private readonly FileProcessingService _fileProcessingService;

    public FilesController(FileProcessingService fileProcessingService)
    {
        _fileProcessingService = fileProcessingService;
    }

    [HttpPost("upload")]
    public async ValueTask<IActionResult> UploadFileAsync(IFormFile file)
    {
        var userId = User.Claims.First(claim => claim.Type == ClaimConstants.UserId).Value;

        return Ok(await _fileProcessingService.UploadFileAsync(file, Guid.Parse(userId)));
    }
}