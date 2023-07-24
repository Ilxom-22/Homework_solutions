namespace Library;

class Program
{
    static void Main(string[] args)
    {
        var harryPotter = new Book("Harry Potter and the Deathly Hallows", "J.K.Rowling");
        var catcher = new Book("The catcher in the Rye", "J.D.Salinger");
        var littleWomen = new Book("Little Women", "Louisa May Alcott");

        var library = new LibraryManagement();

        library.Checkin(harryPotter);
        library.Checkin(harryPotter);
        library.Checkin(harryPotter);

        library.Checkin(catcher);
        library.Checkin(catcher);
        library.Checkin(catcher);
        library.Checkin(catcher);

        library.Checkin(littleWomen);

        library.Check();
        Console.WriteLine();

        library.Checkout(harryPotter._id);
        library.Checkout(harryPotter._id);
        library.Checkout(catcher._id);
        library.Checkout(catcher._id);

        library.Check();
    }
}
