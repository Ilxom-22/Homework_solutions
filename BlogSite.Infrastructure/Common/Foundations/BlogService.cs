using BlogSite.Application.Common.Foundations;
using BlogSite.Domain.Entities;
using BlogSite.Persistence.Repositories.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Security.Authentication;

namespace BlogSite.Infrastructure.Common.Foundations;

public class BlogService : IBlogService
{
    private readonly IBlogRepository _blogRepository;

    public BlogService(IBlogRepository blogRepository) => _blogRepository = blogRepository;

    public IQueryable<Blog> Get(Expression<Func<Blog, bool>>? predicate = default, bool asNoTracking = false) =>
        _blogRepository.Get(predicate, asNoTracking);

    public async ValueTask<IList<Blog>> GetAsync(IEnumerable<Guid> ids, bool asNoTracking = false, CancellationToken cancellationToken = default) =>
        await _blogRepository.GetAsync(ids, asNoTracking, cancellationToken);

    public async ValueTask<Blog?> GetByIdAsync(Guid id, bool asNoTracking = false, CancellationToken cancellationToken = default) =>
        await _blogRepository.GetByIdAsync(id, asNoTracking, cancellationToken);

    public async ValueTask<Blog> CreateAsync(Blog blog, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        if (!IsValidBlog(blog))
            throw new ValidationException("Invalid blog!");

        blog.PublishDate = DateTimeOffset.UtcNow;

        return await _blogRepository.CreateAsync(blog, saveChanges, cancellationToken);
    }

    public async ValueTask<Blog> UpdateAsync(Blog blog, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        if (!IsValidBlog(blog))
            throw new ValidationException("Invalid blog!");

        var foundBlog = await GetByIdAsync(blog.Id, cancellationToken: cancellationToken)
            ?? throw new InvalidOperationException("Blog not found!");

        if (foundBlog.AuthorId != blog.AuthorId)
            throw new AuthenticationException("Forbidden action!");

        foundBlog.Title = blog.Title;
        foundBlog.Content = blog.Content;
        foundBlog.ModifiedDate = DateTimeOffset.UtcNow;

        return await _blogRepository.UpdateAsync(foundBlog, saveChanges, cancellationToken);
    }

    public async ValueTask<Blog> DeleteAsync(Blog blog, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var foundBlog = await GetByIdAsync(blog.Id, true, cancellationToken)
            ?? throw new InvalidOperationException("Blog not found!");

        if (foundBlog.AuthorId != blog.AuthorId)
            throw new AuthenticationException("Forbidden action!");

        return await _blogRepository.DeleteAsync(blog, saveChanges, cancellationToken);
    }

    public async ValueTask<Blog> DeleteByIdAsync(Guid id, Guid authorId, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var foundBlog = await GetByIdAsync(id, true, cancellationToken)
            ?? throw new InvalidOperationException("Blog not found!");

        if (foundBlog.AuthorId != authorId)
            throw new AuthenticationException("Forbidden action!");

        return await _blogRepository.DeleteByIdAsync(id, saveChanges, cancellationToken);
    }

    private static bool IsValidBlog(Blog blog)
        => !(string.IsNullOrWhiteSpace(blog.Title) 
            || string.IsNullOrWhiteSpace(blog.Content));
}