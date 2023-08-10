var registration = RegistrationService.GetInstance();

while (true)
{
    Console.WriteLine("Choose a command(r - register/ d - display all users/ e - exit): ");
    var input = Console.ReadLine();

    switch (input)
    {
        case "r":
            Console.Write("Input name: ");
            var name = Console.ReadLine();
            Console.Write("Input last name: ");
            var lastName = Console.ReadLine();
            Console.Write("Input father name: ");
            var fatherName = Console.ReadLine();
            Console.Write("Input email address: ");
            var emailAddress = Console.ReadLine();
            Console.Write("Input desired username: ");
            var username = Console.ReadLine();
            registration.Register(name, lastName, fatherName, emailAddress, username);
            break;
        case "d":
            registration.Display();
            break;
        case "e":
            return;
    }
}