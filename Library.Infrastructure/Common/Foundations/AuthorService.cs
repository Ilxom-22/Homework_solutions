using Library.Application.Common.Entity;
using Library.Domain.Entities;
using Library.Persistence.DataContexts;
using System.Linq.Expressions;

namespace Library.Infrastructure.Common.Foundations;

public class AuthorService : IEntityBaseService<Author>
{
    private readonly AppDbContext _appDbContext;

    public AuthorService(AppDbContext context)
    {
        _appDbContext = context;        
    }

    public IQueryable<Author> Get(Expression<Func<Author, bool>>? predicate = null)
        => predicate != null ? _appDbContext.Authors.Where(predicate) : _appDbContext.Authors;

    public ValueTask<ICollection<Author>> GetAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken = default)
        => new(Get(author => ids.Contains(author.Id)).ToList());

    public async ValueTask<Author> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        => await _appDbContext.Authors.FindAsync(id, cancellationToken) ?? throw new ArgumentException("Author not found!");

    public async ValueTask<Author> CreateAsync(Author author, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        await _appDbContext.Authors.AddAsync(author, cancellationToken);

        await _appDbContext.SaveChangesAsync();

        return author;
    }

    public async ValueTask<Author> UpdateAsync(Author author, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var foundAuthor = await GetByIdAsync(author.Id, cancellationToken);

        foundAuthor.FirstName = author.FirstName;
        foundAuthor.LastName = author.LastName;

        _appDbContext.Authors.Update(foundAuthor);

        return foundAuthor;
    }

    public async ValueTask<Author> DeleteAsync(Guid id, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var foundAuthor = await GetByIdAsync(id, cancellationToken);

        _appDbContext.Authors.Remove(foundAuthor);

        if (saveChanges) await _appDbContext.SaveChangesAsync();

        return foundAuthor;
    }

    public async ValueTask<Author> DeleteAsync(Author author, bool saveChanges = true, CancellationToken cancellationToken = default)
        => await DeleteAsync(author.Id, saveChanges, cancellationToken);
}