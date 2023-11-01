using Library.Application.Common.Entity;
using Library.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Library.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthorsController : ControllerBase
{
    private readonly IEntityBaseService<Author> _authorService;

    public AuthorsController(IEntityBaseService<Author> authorService)
        => _authorService = authorService;

    [HttpGet]
    public IActionResult GetAllAuthors()
    {
        var result = _authorService.Get(author => true);

        return result.Any() ? Ok(result) : NoContent();    
    }

    [HttpGet("{authorId}")]
    public async ValueTask<IActionResult> GetAuthorById([FromRoute] Guid authorId)
        => Ok(await _authorService.GetByIdAsync(authorId));

    [HttpPost]
    public async ValueTask<IActionResult> CreateAuthor([FromBody] Author author)
        => Ok(await _authorService.CreateAsync(author));

    [HttpPut]
    public async ValueTask<IActionResult> UpdateAuthor([FromBody] Author author)
        => Ok(await _authorService.UpdateAsync(author));

    [HttpDelete("{authorId}")]
    public async ValueTask<IActionResult> DeleteAuthorById([FromRoute] Guid authorId)
        => Ok(await _authorService.DeleteAsync(authorId));
}