using Books;

List<Book> books = new List<Book>()
{
    new ("Whispers of the Lost Realm", "Emily Turner", 8),
    new ("Echoes in the Mist", "Michael Greene", 9),
    new ("Serenade for the Stars", "Jennifer Mitchell", 5),
    new ("Crimson Secrets", "Emily Turner", 6),
    new ("Waves of Destiny", "Michael Greene", 10),
    new ("Silent Whispers", "Jennifer Mitchell", 7),
    new ("Eternal Skies", "Emily Turner", 4),
    new ("Forgotten Realms", "Michael Greene", 3),
    new ("Melodies of Midnight", "Jennifer Mitchell", 2),
    new ("Abyss of Illusions", "Emily Turner", 1)
};


var emilyBooks = books.Where(book => book.Author == "Emily Turner").OrderByDescending(book => book.Rating).ToList();

Console.WriteLine($"Best Book of {emilyBooks[0].Author} - {emilyBooks[0].Name} - {emilyBooks[0].Rating}");
Console.WriteLine($"Worst Book of {emilyBooks[^1].Author} - {emilyBooks[^1].Name} - {emilyBooks[^1].Rating}");