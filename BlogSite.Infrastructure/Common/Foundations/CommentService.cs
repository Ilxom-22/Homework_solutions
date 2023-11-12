using BlogSite.Application.Common.Foundations;
using BlogSite.Domain.Entities;
using BlogSite.Persistence.Repositories.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Security.Authentication;

namespace BlogSite.Infrastructure.Common.Foundations;

public class CommentService : ICommentService
{
    private readonly ICommentRepository _commentRepository;

    public CommentService(ICommentRepository roleRepository) => _commentRepository = roleRepository;

    public IQueryable<Comment> Get(Expression<Func<Comment, bool>>? predicate = default, bool asNoTracking = false) =>
        _commentRepository.Get(predicate, asNoTracking);

    public async ValueTask<IList<Comment>> GetAsync(IEnumerable<Guid> ids, bool asNoTracking = false, CancellationToken cancellationToken = default) =>
       await _commentRepository.GetAsync(ids, asNoTracking, cancellationToken);

    public async ValueTask<Comment?> GetByIdAsync(Guid id, bool asNoTracking = false, CancellationToken cancellationToken = default) =>
       await _commentRepository.GetByIdAsync(id, asNoTracking, cancellationToken);

    public async ValueTask<Comment> CreateAsync(Comment comment, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        if (!IsValidComment(comment))
            throw new ValidationException("Invalid comment.");

        comment.CreatedDate = DateTimeOffset.UtcNow;

        return await _commentRepository.CreateAsync(comment, saveChanges, cancellationToken);
    }

    public async ValueTask<Comment> UpdateAsync(Comment comment, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        if (!IsValidComment(comment))
            throw new ValidationException("Invalid comment.");

        var foundComment = await GetByIdAsync(comment.Id, cancellationToken: cancellationToken)
            ?? throw new InvalidOperationException("Comment not found!");

        if (foundComment.AuthorId != comment.AuthorId)
            throw new AuthenticationException("Forbidden action!");

        foundComment.Content = comment.Content;
        foundComment.ModifiedDate = DateTimeOffset.UtcNow;

        return await _commentRepository.UpdateAsync(foundComment, saveChanges, cancellationToken);
    }

    public async ValueTask<Comment> DeleteAsync(Comment comment, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var foundComment = await GetByIdAsync(comment.Id, cancellationToken: cancellationToken)
           ?? throw new InvalidOperationException("Comment not found!");

        if (foundComment.AuthorId != comment.AuthorId)
            throw new AuthenticationException("Forbidden action!");

        return await _commentRepository.DeleteAsync(comment, saveChanges, cancellationToken);
    }

    public async ValueTask<Comment> DeleteByIdAsync(Guid id, Guid authorId, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var foundComment = await GetByIdAsync(id, cancellationToken: cancellationToken)
          ?? throw new InvalidOperationException("Comment not found!");

        if (foundComment.AuthorId != authorId)
            throw new AuthenticationException("Forbidden action!");

        return await _commentRepository.DeleteByIdAsync(id, saveChanges, cancellationToken);
    }

    private static bool IsValidComment(Comment comment)
        => !string.IsNullOrWhiteSpace(comment.Content);
}