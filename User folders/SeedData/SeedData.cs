using User_folders.Models;

namespace User_folders.SeedData;

public static class SeedData
{
    public static ICollection<User> GetUsers()
    {
        List<User> users = new List<User>
        {
            new User("John", "Doe", "john.doe@example.com", "p@ssw0rd1"),
            new User("Alice", "Smith", "alice.smith@example.com", "secure123"),
            new User("Michael", "Johnson", "michael.johnson@example.com", "passw0rd!"),
            new User("Sarah", "Brown", "sarah.brown@example.com", "myP@ssword"),
            new User("David", "Wilson", "david.wilson@example.com", "d@ve1234"),
            new User("Emily", "Miller", "emily.miller@example.com", "emilyP@ss"),
            new User("James", "Anderson", "james.anderson@example.com", "j@mes567"),
            new User("Olivia", "Martinez", "olivia.martinez@example.com", "ol1viaPwd"),
            new User("Daniel", "Harris", "daniel.harris@example.com", "d@nnyPass"),
            new User("Sophia", "Garcia", "sophia.garcia@example.com", "s0phia#123")
        };

        return users;
    }

    public static ICollection<string> GetFileExtensions()
        => new List<string>
            { ".txt", ".doc", ".docx", ".pdf", ".jpg", ".png", ".ppt", ".zip", ".mp3", ".mp4", ".csv", ".json" };
}