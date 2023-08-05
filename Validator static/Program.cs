var email = "james@gmail.com";
var email2 = "james-carter.com";

Validator.IsValidEmail(email, out string validEmail);
Print(email, validEmail);
Validator.IsValidEmail(email2, out string validEmail2);
Print(email2, validEmail2);
Console.WriteLine();


var name = "   James   ";
var name2 = "James2";

Validator.IsValidName(name, out string validName);
Print(name, validName);
Validator.IsValidName(name2, out string validName2);
Print(name2, validName2);
Console.WriteLine();


var number = "+998937771123";
var number2 = "+123456789101";

Validator.IsValidPhoneNumber(number, out string validNumber);
Print(number, validNumber);
Validator.IsValidPhoneNumber(number2, out string validNumber2);
Print(number2, validNumber2);
Console.WriteLine();


var age = 33;
var age1 = 255;

if(Validator.IsValidAge(age))
    Console.WriteLine($"{age} - Valid!");
else
    Console.WriteLine($"{age} - Invalid!");


if (Validator.IsValidAge(age1))
    Console.WriteLine($"{age1} - Valid!");
else
    Console.WriteLine($"{age1} - Invalid!");

void Print(string test, string valid)
{
    if (valid != null)
        Console.WriteLine($"{valid} - Valid!");
    else
        Console.WriteLine($"{test} - Invalid!");
}