﻿using BlogSite.Application.Common.Foundations;
using BlogSite.Domain.Entities;
using BlogSite.Persistence.Repositories.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace BlogSite.Infrastructure.Common.Foundations;

public class BlogService : IBlogService
{
    private readonly IBlogRepository _blogRepository;

    public BlogService(IBlogRepository blogRepository) => _blogRepository = blogRepository;

    public IQueryable<Blog> Get(Expression<Func<Blog, bool>>? predicate = default, bool asNoTracking = false) =>
        _blogRepository.Get(predicate, asNoTracking);

    public ValueTask<IList<Blog>> GetAsync(IEnumerable<Guid> ids, bool asNoTracking = false, CancellationToken cancellationToken = default) =>
        _blogRepository.GetAsync(ids, asNoTracking, cancellationToken);

    public ValueTask<Blog?> GetByIdAsync(Guid id, bool asNoTracking = false, CancellationToken cancellationToken = default) =>
        _blogRepository.GetByIdAsync(id, asNoTracking, cancellationToken);

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

        foundBlog.Title = blog.Title;
        foundBlog.Content = blog.Content;
        foundBlog.ModifiedDate = DateTimeOffset.UtcNow;

        return await _blogRepository.CreateAsync(blog, saveChanges, cancellationToken);
    }

    public ValueTask<Blog> DeleteAsync(Blog blog, bool saveChanges = true, CancellationToken cancellationToken = default) =>
        _blogRepository.DeleteAsync(blog, saveChanges, cancellationToken);

    public ValueTask<Blog> DeleteByIdAsync(Guid id, bool saveChanges = true, CancellationToken cancellationToken = default) =>
        _blogRepository.DeleteByIdAsync(id, saveChanges, cancellationToken);

    private static bool IsValidBlog(Blog blog)
        => !(string.IsNullOrWhiteSpace(blog.Title) 
            || string.IsNullOrWhiteSpace(blog.Content));
}