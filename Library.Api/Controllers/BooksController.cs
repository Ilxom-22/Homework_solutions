using Library.Application.Common.Entity;
using Library.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Library.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
    private readonly IEntityBaseService<Book> _bookService;

    public BooksController(IEntityBaseService<Book> bookService)
        => _bookService = bookService;

    [HttpGet]
    public IActionResult GetAllBooks()
    {
        var result = _bookService.Get(book => true);

        return result.Any() ? Ok(result) : NoContent();
    }

    [HttpGet("{bookId}")]
    public async ValueTask<IActionResult> GetBookById([FromRoute] Guid bookId)
        => Ok(await _bookService.GetByIdAsync(bookId));

    [HttpPost]
    public async ValueTask<IActionResult> CreateBook([FromBody] Book book)
        => Ok(await _bookService.CreateAsync(book));

    [HttpPut]
    public async ValueTask<IActionResult> UpdateBook([FromBody] Book book)
        => Ok(await _bookService.UpdateAsync(book));

    [HttpDelete("{bookId}")]
    public async ValueTask<IActionResult> DeleteBookById([FromRoute] Guid bookId)
        => Ok(await _bookService.DeleteAsync(bookId));
}