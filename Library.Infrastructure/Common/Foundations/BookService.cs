using Library.Application.Common.Entity;
using Library.Domain.Entities;
using Library.Persistence.DataContexts;
using System.Linq.Expressions;

namespace Library.Infrastructure.Common.Foundations;

public class BookService : IEntityBaseService<Book>
{
    private readonly AppDbContext _appDbContext;

    public BookService(AppDbContext context)
    {
        _appDbContext = context;
    }

    public IQueryable<Book> Get(Expression<Func<Book, bool>>? predicate = null)
       => predicate != null ? _appDbContext.Books.Where(predicate) : _appDbContext.Books;

    public ValueTask<ICollection<Book>> GetAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken = default)
        => new(Get(book => ids.Contains(book.Id)).ToList());

    public async ValueTask<Book> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        => await _appDbContext.Books.FindAsync(id, cancellationToken) ?? throw new ArgumentException("Book not found");

    public async ValueTask<Book> CreateAsync(Book book, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        await _appDbContext.Books.AddAsync(book, cancellationToken);

        if (saveChanges) await _appDbContext.SaveChangesAsync(cancellationToken);

        return book;
    }

    public async ValueTask<Book> UpdateAsync(Book book, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var foundBook = await GetByIdAsync(book.Id, cancellationToken);

        foundBook.AuthorId = book.AuthorId;
        foundBook.Description = book.Description;
        foundBook.Title = book.Title;

        _appDbContext.Books.Update(foundBook);

        if (saveChanges) await _appDbContext.SaveChangesAsync();

        return foundBook;
    }

    public async ValueTask<Book> DeleteAsync(Guid id, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var foundBook = await GetByIdAsync(id, cancellationToken);

        _appDbContext.Books.Remove(foundBook);

        if (saveChanges) await _appDbContext.SaveChangesAsync();

        return foundBook;
    }

    public async ValueTask<Book> DeleteAsync(Book book, bool saveChanges = true, CancellationToken cancellationToken = default)
     => await DeleteAsync(book.Id, saveChanges, cancellationToken);
}