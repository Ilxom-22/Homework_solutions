using AutoMapper;
using BlogSite.Application.Common.Dtos;
using BlogSite.Application.Common.Foundations;
using BlogSite.Application.Common.Identity.Constants;
using BlogSite.Application.Common.ManagementServices;
using BlogSite.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogSite.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BlogsController : ControllerBase
{
    private readonly IBlogService _blogService;
    private readonly IBlogManagementService _blogManagementService;
    private readonly IMapper _mapper;

    public BlogsController(IBlogService blogService, IBlogManagementService blogManagementService, IMapper mapper)
    {
        _blogService = blogService;
        _blogManagementService = blogManagementService;
        _mapper = mapper;
    }

    [HttpGet("bloggers/popular")]
    public async ValueTask<IActionResult> GetPopularBloggers(CancellationToken cancellationToken)
    {
        var bloggers = await _blogManagementService.GetPopularBloggers(cancellationToken);
        var result = bloggers.Select(_mapper.Map<UserDto>);

        return result.Any() ? Ok(result) : NoContent();
    }

    [Authorize(Roles = "Admin,Author,Reader")]
    [HttpGet("{authorId}")]
    public async ValueTask<IActionResult> GetBlogsByAuthor([FromRoute] Guid authorId, CancellationToken cancellationToken)
    {
        var blogs = await _blogManagementService.GetBlogsByAuthorId(authorId, cancellationToken);

        var blogDtos = blogs.Select(_mapper.Map<BlogDto>);

        return blogDtos.Any() ? Ok(blogDtos) : NoContent();
    }

    [Authorize(Roles = "Author")]
    [HttpPost]
    public async ValueTask<IActionResult> CreateBlogAsync([FromBody] BlogDto blogDto)
    {
        var authorId = Guid.Parse(User.Claims.First(claim => claim.Type == ClaimConstants.UserId).Value);
        
        var blog = _mapper.Map<Blog>(blogDto);
        blog.AuthorId = authorId;

        return Ok(await _blogService.CreateAsync(blog));
    }

    [Authorize(Roles = "Author")]
    [HttpPut]
    public async ValueTask<IActionResult> UpdateBlogAsync([FromBody] BlogDto blogDto, CancellationToken cancellationToken)
    {
        var authorId = Guid.Parse(User.Claims.First(claim => claim.Type == ClaimConstants.UserId).Value);

        var blog = _mapper.Map<Blog>(blogDto);
        blog.AuthorId = authorId;

        return Ok(await _blogService.UpdateAsync(blog, cancellationToken: cancellationToken));
    }

    [Authorize(Roles = "Author")]
    [HttpDelete("{blogId}")]
    public async ValueTask<IActionResult> DeleteByIdAsync([FromRoute] Guid blogId, CancellationToken cancellationToken)
    {
        var authorId = Guid.Parse(User.Claims.First(claim => claim.Type == ClaimConstants.UserId).Value);

        await _blogService.DeleteByIdAsync(blogId, authorId, cancellationToken: cancellationToken);

        return NoContent();
    }
}