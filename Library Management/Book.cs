namespace Library;

public class Book
{
    public Guid _id = Guid.NewGuid();
    private string _title;
    private string _author;

    public Book(string title, string author)
    {
        _title = title;
        _author = author;
    }


    public override string ToString()
    {
        return $"{_title} - {_author}";
    }
}