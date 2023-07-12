string name;
string lastName;
byte age;
bool success;

// Name input.
do
{
    Console.Write("Input your name: ");
    name = Console.ReadLine();
} while (string.IsNullOrWhiteSpace(name));

// Last Name input.
do
{
    Console.Write("Input your last name: ");
    lastName = Console.ReadLine();
} while (string.IsNullOrWhiteSpace(lastName));

// Age input.
do
{
    Console.Write("Input your age: ");
    success = byte.TryParse(Console.ReadLine(), out age);
} while (!success || age > 120 || age < 12);



// Printing out the credentials.
Console.WriteLine(@$"Name: {name}
Last Name: {lastName}
Age: {age}");

// How to do a function here?
