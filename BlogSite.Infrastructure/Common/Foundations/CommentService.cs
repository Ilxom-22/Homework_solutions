using BlogSite.Application.Common.Foundations;
using BlogSite.Domain.Entities;
using BlogSite.Persistence.Repositories.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

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

        return await _commentRepository.CreateAsync(comment, saveChanges, cancellationToken);
    }

    public async ValueTask<Comment> UpdateAsync(Comment comment, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        if (!IsValidComment(comment))
            throw new ValidationException("Invalid comment.");

        var foundComment = await GetByIdAsync(comment.Id, cancellationToken: cancellationToken)
            ?? throw new InvalidOperationException("Comment not found!");

        foundComment.Content = comment.Content;

        return await _commentRepository.UpdateAsync(foundComment, saveChanges, cancellationToken);
    }

    public async ValueTask<Comment> DeleteAsync(Comment comment, bool saveChanges = true, CancellationToken cancellationToken = default) =>
        await _commentRepository.DeleteAsync(comment, saveChanges, cancellationToken);

    public async ValueTask<Comment> DeleteByIdAsync(Guid id, bool saveChanges = true, CancellationToken cancellationToken = default) =>
        await _commentRepository.DeleteByIdAsync(id, saveChanges, cancellationToken);

    private static bool IsValidComment(Comment comment)
        => !string.IsNullOrWhiteSpace(comment.Content);
}