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
[Authorize(Roles = "Reader, Author, Admin")]
public class CommentsController : ControllerBase
{
    private readonly ICommentService _commentService;
    private readonly IBlogManagementService _blogManagementService;
    private readonly IMapper _mapper;

    public CommentsController(ICommentService commentService, IBlogManagementService blogManagementService, IMapper mapper)
    {
        _commentService = commentService;
        _blogManagementService = blogManagementService;
        _mapper = mapper;
    }

    [HttpGet("{blogId}")]
    public async ValueTask<IActionResult> GetCommentsByBlogIdAsync([FromRoute] Guid blogId, CancellationToken cancellationToken)
    {
        var comments = await _blogManagementService.GetCommentsByBlogIdAsync(blogId, cancellationToken);

        var result = comments.Select(_mapper.Map<CommentDto>);

        return result.Any() ? Ok(result) : NoContent();
    }

    [HttpPost]
    public async ValueTask<IActionResult> CreateCommentAsync([FromBody] CommentDto commentDto, CancellationToken cancellationToken)
    {
        var comment = _mapper.Map<Comment>(commentDto);
        comment.AuthorId = Guid.Parse(User.Claims.First(claim => claim.Type == ClaimConstants.UserId).Value);

        return Ok(await _blogManagementService.CreateCommentAsync(comment, cancellationToken));
    }

    [HttpPut]
    public async ValueTask<IActionResult> UpdateCommentAsync([FromBody] CommentDto commentDto, CancellationToken cancellationToken)
    {
        var comment = _mapper.Map<Comment>(commentDto);
        comment.AuthorId = Guid.Parse(User.Claims.First(claim => claim.Type == ClaimConstants.UserId).Value);

        return Ok(await _commentService.UpdateAsync(comment, cancellationToken: cancellationToken));
    }

    [HttpDelete("{commentId}")]
    public async ValueTask<IActionResult> DeleteByIdAsync([FromRoute] Guid commentId, CancellationToken cancellationToken)
    {
        var authorId = Guid.Parse(User.Claims.First(claim => claim.Type == ClaimConstants.UserId).Value);

        return Ok(await _commentService.DeleteByIdAsync(commentId, authorId, cancellationToken: cancellationToken));
    }
}