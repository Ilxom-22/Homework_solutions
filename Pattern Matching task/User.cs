﻿public class User : IEntity
{ 
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public User(string firstName, string lastName)
    {
        Id = Guid.NewGuid();
        FirstName = firstName;
        LastName = lastName;
    }

    public override string ToString()
        => $"{FirstName} {LastName}";
}