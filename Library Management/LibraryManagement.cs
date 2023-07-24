namespace Library;

public class LibraryManagement
{
    private readonly Dictionary<Book, int> _books = new ();


    public bool Checkout(Guid bookId)
    {
        foreach (var book in _books)
        {
            if (book.Key._id == bookId && book.Value > 1)
            {
                _books[book.Key]--;
                return true;
            }
        }
        return false;
    }



    public void Checkin(Book book)
    {
        if (_books.ContainsKey(book))
            _books[book]++;
        else
            _books.Add(book, 1);
    }



    public void Check()
    {
        foreach (var book in _books)
            Console.WriteLine($"{book.Value} - {book.Key}");
        
    }
}