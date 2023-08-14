namespace Books;

internal class Book
{
    public Book(string name, string author, byte rating)
    {
        Name = name;
        Author = author;
        Rating = rating;
    }

    private byte _rating;
    public string Name { get; set; }
    public byte Rating { 
        get => _rating; 
        set => _rating = (value is > 0 and <= 10) 
            ? value 
            : throw new ArgumentOutOfRangeException(nameof(Rating), "Rating must be within 1 and 10 stars!"); 
    }
    public string Author { get; set; }
}

